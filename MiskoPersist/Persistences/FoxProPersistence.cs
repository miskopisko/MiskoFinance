using System;
using System.Data;
using System.Data.OleDb;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.MoneyType;

namespace MiskoPersist.Persistences
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
                        innerParam.ParameterName = position.ToString();
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
            throw new MiskoException("FoxPro UPDATEs are implemented on a class by class basis by overriding the Store(session) method");
        }

        protected override void GenerateDeleteStatement(AbstractStoredData clazz, Type type)
        {
            throw new MiskoException("FoxPro DELETEs are implemented on a class by class basis by overriding the Remove(session) method");
        }

        protected override void GenerateInsertStatement(AbstractStoredData clazz, Type type)
        {
            throw new MiskoException("FoxPro INSERTSs are implemented on a class by class basis by overriding the Create(session) method");
        }

        protected override string GenerateCreateTableStatement(Type type)
        {
            throw new MiskoException("Automated CREATE TABLE statements for FoxPro are not supported at this time");
        }

        #endregion
    }
}
