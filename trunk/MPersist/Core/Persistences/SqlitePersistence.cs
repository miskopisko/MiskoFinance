using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;

namespace MPersist.Core.Persistences
{
    class SqlitePersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlitePersistence));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public SqlitePersistence(Session session) : base(session)
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
                SQLiteParameter param = new SQLiteParameter();
                param.ParameterName = "@param" + position;

                if (parameter == null)
                {
                    param.IsNullable = true;
                    param.Value = DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is StoredData)
                {
                    param.IsNullable = false;
                    param.DbType = DbType.Int64;
                    param.Value = parameter != null ? (Object)((StoredData)parameter).Id.Value : DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractEnum)
                {
                    param.IsNullable = true;
                    param.DbType = DbType.Int32;
                    param.Value = ((AbstractEnum)parameter).IsSet ? (Object)((AbstractEnum)parameter).Value : DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is Array)
                {
                    String firstHalf = mCommand_.CommandText.Substring(0, mCommand_.CommandText.IndexOf(param.ParameterName));
                    String secondHalf = mCommand_.CommandText.Substring(mCommand_.CommandText.IndexOf(param.ParameterName) + 7);
                    String middle = "";

                    foreach (Object o in ((Array)parameter))
                    {
                        SQLiteParameter innerParam = new SQLiteParameter();
                        innerParam.ParameterName = "@param" + position;
                        innerParam.Value = o;
                        middle += innerParam.ParameterName + ", ";
                        mCommand_.Parameters.Add(innerParam);
                        position++;
                    }

                    mCommand_.CommandText = firstHalf + middle.Substring(0, middle.Length - 2) + secondHalf;
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

        protected override void GenerateUpdateStatement(StoredData clazz, Type type)
        {
            if (clazz != null)
            {
                String sql = "";
                List<Object> parameters = new List<Object>();

                sql += "UPDATE " + type.Name.ToUpper() + Environment.NewLine + "SET    ";

                foreach (PropertyInfo property in clazz.GetStoredProperties(type))
                {
                    sql += clazz.GetColumnName(property) + " = ?, " + Environment.NewLine + "       ";
                    parameters.Add(property.GetValue(clazz, null));
                }

                sql += "DTMODIFIED = DATETIME('NOW')," + Environment.NewLine;
                sql += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                sql += "WHERE  ID = ?" + Environment.NewLine;
                sql += "AND    ROWVER = ?;";

                parameters.Add(clazz.Id);
                parameters.Add(clazz.RowVer);

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }
        }

        protected override void GenerateDeleteStatement(StoredData clazz, Type type)
        {
            if (clazz != null)
            {
                String sql = "";
                List<Object> parameters = new List<Object>();

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

        protected override void GenerateInsertStatement(StoredData clazz, Type type)
        {
            if (clazz != null)
            {
                String sql = "";
                List<Object> parameters = new List<Object>();
                PropertyInfo[] properties = clazz.GetStoredProperties(type);

                sql += "INSERT INTO " + type.Name.ToUpper() + " (ID";

                foreach (PropertyInfo property in properties)
                {
                    sql += ", " + clazz.GetColumnName(property);
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

                foreach (PropertyInfo property in properties)
                {
                    sql += "?, ";
                    parameters.Add(property.GetValue(clazz, null));
                }

                sql += "DATETIME('NOW'), DATETIME('NOW'), 0);";

                if (type.BaseType.Equals(typeof(StoredData)))
                {
                    sql += Environment.NewLine + "SELECT LAST_INSERT_ROWID() AS ID;";
                }
                else
                {
                    sql += Environment.NewLine + "SELECT ? AS ID;";
                    parameters.Add(clazz.Id);
                }

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }
        }

        #endregion
    }
}
