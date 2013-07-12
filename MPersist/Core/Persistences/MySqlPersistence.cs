using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using MySql.Data.MySqlClient;

namespace MPersist.Core.Persistences
{
    class MySqlPersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(MySqlPersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public MySqlPersistence(Session session) : base(session)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override void SetParameters(Object[] parameters)
        {
            // Normalize the parameters by replacing typical ? marks with @param values
            Int32 end = 0;
            Int32 position = 0;
            while ((end = mCommand_.CommandText.IndexOf("?")) > 0)
            {
                mCommand_.CommandText = mCommand_.CommandText.Substring(0, end) + ("@param" + position++) + mCommand_.CommandText.Substring(end + 1);
                end = -1;
            }

            position = 0;
            foreach (Object parameter in parameters)
            {
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@param" + position;

                if (parameter == null)
                {
                    param.IsNullable = true;
                    param.Value = DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractStoredData)
                {
                    param.IsNullable = false;
                    param.MySqlDbType = MySqlDbType.Int64;
                    param.Value = parameter != null ? (Object)((AbstractStoredData)parameter).Id.Value : DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractEnum)
                {
                    param.IsNullable = true;
                    param.MySqlDbType = MySqlDbType.Int32;
                    param.Value = ((AbstractEnum)parameter).IsSet ? (Object)((AbstractEnum)parameter).Value : DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is Array)
                {
                    String firstHalf = mCommand_.CommandText.Substring(0, mCommand_.CommandText.IndexOf(param.ParameterName));
                    String secondHalf = mCommand_.CommandText.Substring(mCommand_.CommandText.IndexOf(param.ParameterName)+7);
                    String middle = "";

                    foreach (Object o in ((Array)parameter))
                    {                        
                        MySqlParameter innerParam = new MySqlParameter();
                        innerParam.ParameterName = "@param" + position;
                        innerParam.Value = o;
                        middle += innerParam.ParameterName + ", ";
                        mCommand_.Parameters.Add(innerParam);
                        position++;
                    }

                    mCommand_.CommandText = firstHalf + middle.Substring(0, middle.Length-2) + secondHalf;
                }
                else if (parameter is Money)
                {
                    param.DbType = DbType.Decimal;
                    param.Value = ((Money)parameter).ToDecimal(null);
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is PrimaryKey)
                {
                    param.DbType = DbType.Int64;
                    param.Value = ((PrimaryKey)parameter).Value;
                    mCommand_.Parameters.Add(param);
                }
                else
                {
                    param.Value = parameter;
                    mCommand_.Parameters.Add(param);
                }
                
                position++;
            }
        }

        protected override void GenerateUpdateStatement(AbstractStoredData clazz, Type type)
        {
            String sql = "";
            List<Object> parameters = new List<Object>();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (clazz != null)
            {
                sql += "UPDATE " + type.Name + Environment.NewLine + "SET    ";

                for (int i = 0; i < properties.Length; i++)
                {
                    foreach (Attribute attribute in properties[i].GetCustomAttributes(false))
                    {
                        if (attribute is StoredAttribute)
                        {
                            if (((StoredAttribute)attribute).UseInSql)
                            {
                                sql += properties[i].Name.ToUpper() + " = ?, " + Environment.NewLine + "       ";
                                parameters.Add(properties[i].GetValue(clazz, null));
                            }
                        }
                    }
                }

                sql += "DTMODIFIED = NOW()," + Environment.NewLine;
                sql += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                sql += "WHERE  ID = ?" + Environment.NewLine;
                sql += "AND    ROWVER = ?;";

                parameters.Add(clazz.Id);
                parameters.Add(clazz.RowVer);

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }
        }

        protected override void GenerateDeleteStatement(AbstractStoredData clazz, Type type)
        {
            String sql = "";
            List<Object> parameters = new List<Object>();

            if (clazz != null)
            {
                sql += "DELETE" + Environment.NewLine;
                sql += "FROM   " + type.Name + Environment.NewLine;
                sql += "WHERE  ID = ?" + Environment.NewLine;
                sql += "AND    ROWVER = ?;";

                parameters.Add(-clazz.Id);
                parameters.Add(clazz.RowVer);

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }
        }

        protected override void GenerateInsertStatement(AbstractStoredData clazz, Type type)
        {
            String sql = "";
            List<Object> parameters = new List<Object>();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (clazz != null)
            {
                sql += "INSERT INTO " + type.Name + " (ID";

                for (int i = 0; i < properties.Length; i++)
                {
                    foreach (Attribute attribute in properties[i].GetCustomAttributes(false))
                    {
                        if (attribute is StoredAttribute)
                        {
                            if (((StoredAttribute)attribute).UseInSql)
                            {
                                sql += ", " + properties[i].Name.ToUpper();
                            }
                        }
                    }
                }

                sql += ", DTCREATED, DTMODIFIED, ROWVER)" + Environment.NewLine + "VALUES (?, ";

                if (clazz.Id > 0)
                {
                    parameters.Add(clazz.Id);
                }
                else
                {
                    parameters.Add(DBNull.Value);
                }

                for (int i = 0; i < properties.Length; i++)
                {
                    foreach (Attribute attribute in properties[i].GetCustomAttributes(false))
                    {
                        if (attribute is StoredAttribute)
                        {
                            if (((StoredAttribute)attribute).UseInSql)
                            {
                                sql += "?, ";
                                parameters.Add(properties[i].GetValue(clazz, null));
                            }
                        }
                    }
                }

                sql += "NOW(), NOW(), 0);";

                if (type.BaseType.Equals(typeof(AbstractStoredData)))
                {
                    sql += Environment.NewLine + "SELECT LAST_INSERT_ID() AS ID;";
                }
                else
                {
                    sql += Environment.NewLine + "SELECT ? AS ID;";
                    parameters.Add(clazz.Id);
                }
            }

            mCommand_.CommandText = sql;
            SetParameters(parameters.ToArray());
        }

        #endregion
    }
}
