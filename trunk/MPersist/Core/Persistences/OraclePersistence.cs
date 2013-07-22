using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using Oracle.DataAccess.Client;

namespace MPersist.Core.Persistences
{
    class OraclePersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(OraclePersistence));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public OraclePersistence(Session session) : base(session)
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
                mCommand_.CommandText = mCommand_.CommandText.Substring(0, end) + (":param" + position++) + mCommand_.CommandText.Substring(end + 1);
                end = -1;
            }

            position = 0;
            foreach (Object parameter in parameters)
            {
                OracleParameter param = new OracleParameter();
                param.ParameterName = ":param" + position;

                if (parameter == null)
                {
                    param.IsNullable = true;
                    param.Value = DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractStoredData)
                {
                    param.IsNullable = false;
                    param.DbType = DbType.Int64;
                    param.Value = parameter != null ? (Object)((AbstractStoredData)parameter).Id.Value : DBNull.Value;
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
                        OracleParameter innerParam = new OracleParameter();
                        innerParam.ParameterName = ":param" + position;
                        innerParam.Value = o;
                        middle += innerParam.ParameterName + ", ";
                        mCommand_.Parameters.Add(innerParam);
                        position++;
                    }

                    mCommand_.CommandText = firstHalf + middle.Substring(0, middle.Length - 2) + secondHalf;
                }
                else if(parameter is Money)
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

        protected override void GenerateUpdateStatement(AbstractStoredData clazz)
        {
            /*String sql = "";
            List<Object> parameters = new List<Object>();
            
            if (clazz != null)
            {
                sql += "UPDATE " + type.Name.ToUpper() + Environment.NewLine + "SET    ";

                foreach (PropertyInfo property in AbstractStoredData.GetStoredProperties(type))
                {
                    sql += clazz.GetColumnName(property) + " = ?, " + Environment.NewLine + "       ";
                    parameters.Add(property.GetValue(clazz, null));
                }
                
                sql += "DTMODIFIED = SYSDATE," + Environment.NewLine;
                sql += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                sql += "WHERE  ID = ?" + Environment.NewLine;
                sql += "AND    ROWVER = ?";

                parameters.Add(clazz.Id);
                parameters.Add(clazz.RowVer);

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }*/
        }

        protected override void GenerateDeleteStatement(AbstractStoredData clazz)
        {
            /*String sql = "";
            List<Object> parameters = new List<Object>();

            if (clazz != null)
            {
                sql += "DELETE" + Environment.NewLine;
                sql += "FROM   " + type.Name.ToUpper() + Environment.NewLine;
                sql += "WHERE  ID = ?" + Environment.NewLine;
                sql += "AND    ROWVER = ?;";

                parameters.Add(-clazz.Id);
                parameters.Add(clazz.RowVer);

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }*/
        }

        protected override void GenerateInsertStatement(AbstractStoredData clazz)
        {
            if (clazz != null)
            {
                String sql = "";
                List<Object> parameters = new List<Object>();

                List<Type> types = new List<Type>();
                Type currentType = clazz.GetType();
                while (!currentType.Equals(typeof(AbstractStoredData)))
                {
                    types.Add(currentType);
                    currentType = currentType.BaseType;
                }

                for (int i = types.Count - 1; i >= 0; i--)
                {
                    PropertyInfo[] properties = AbstractStoredData.GetStoredProperties(types[i]);

                    sql += "INSERT INTO " + types[i].Name.ToUpper() + " (ID";

                    foreach (PropertyInfo property in properties)
                    {
                        sql += ", " + clazz.GetColumnName(property);
                    }

                    sql += ", DTCREATED, DTMODIFIED, ROWVER)" + Environment.NewLine + "VALUES (";

                    if (types[i].BaseType.Equals(typeof(AbstractStoredData)))
                    {
                        sql += "SQ_" + clazz.GetType().Name.ToUpper() + ".NEXTVAL, ";
                    }
                    else
                    {
                        sql += "SQ_" + clazz.GetType().Name.ToUpper() + ".CURRVAL, ";
                    }

                    foreach (PropertyInfo property in properties)
                    {
                        sql += "?, ";
                        parameters.Add(property.GetValue(clazz, null));
                    }

                    sql += "SYSDATE, SYSDATE, 0)";

                    if (types[i].BaseType.Equals(typeof(AbstractStoredData)))
                    {
                        sql += Environment.NewLine + "RETURNING ID INTO :LASTID;" + Environment.NewLine;
                    }
                    else
                    {
                        sql += ";";
                    }
                }

                mCommand_.CommandText = sql;
                SetParameters(parameters.ToArray());
            }
        }

        #endregion
    }
}
