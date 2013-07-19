using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using System.Reflection;

namespace MPersist.Core.Persistences
{
    class FoxProPersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(FoxProPersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public FoxProPersistence(Session session) : base(session)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Override Methods

        protected override void SetParameters(Object[] parameters)
        {
            Int32 position = 0;
            foreach (Object parameter in parameters)
            {
                OleDbParameter param = new OleDbParameter();
                param.ParameterName = position.ToString();

                if (parameter == null)
                {
                    param.IsNullable = true;
                    param.Value = DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractStoredData)
                {
                    param.IsNullable = false;
                    param.OleDbType = OleDbType.Integer;
                    param.Value = parameter != null ? (Object)((AbstractStoredData)parameter).Id : DBNull.Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is AbstractEnum)
                {
                    param.IsNullable = true;
                    param.OleDbType = OleDbType.Integer;
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
                        OleDbParameter innerParam = new OleDbParameter();
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
                    param.DbType = DbType.Int32;
                    param.Value = ((PrimaryKey)parameter).Value;
                    mCommand_.Parameters.Add(param);
                }
                else if (parameter is Int64)
                {
                    param.DbType = DbType.Int32;
                    param.Value = parameter;
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

            if (clazz != null)
            {
                sql += "UPDATE " + clazz.GetType().Name + Environment.NewLine + "SET    ";

                foreach (PropertyInfo property in clazz.GetStoredProperties())
                {
                    sql += clazz.GetColumnName(property) + " = ?, " + Environment.NewLine + "       ";
                    parameters.Add(property.GetValue(clazz, null));
                }

                sql += "DTMODIFIED = DATETIME()," + Environment.NewLine;
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
            throw new NotImplementedException("Cannot insert into FoxPro tables yet. Hopefully soon!");
        }

        #endregion
    }
}
