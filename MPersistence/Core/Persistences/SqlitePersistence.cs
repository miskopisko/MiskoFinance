using System;
using MPersist.Core;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;

namespace MPersistence.Core.Persistences
{
    class SqlitePersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlitePersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public SqlitePersistence(Session session) : base(session)
        {
            command_ = session.Connection.CreateCommand();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override void FillDbParameters()
        {
            foreach (Parameter p in Parameters)
            {
                ((SQLiteCommand)command_).Parameters.AddWithValue(p.ParameterName, p.Value);
            }
        }

        protected override String GenerateSelectStatement(Type clazz)
        {
            String result = "";

            if (clazz != null && clazz.IsSubclassOf(typeof(AbstractStoredData)))
            {
                result += "SELECT ";

                PropertyInfo[] properties = clazz.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    result += properties[i].Name.ToUpper() + (i + 1 < properties.Length ? ", " : "");
                }

                result += Environment.NewLine;
                result += "  FROM " + clazz.Name.ToUpper();

                for (Int32 i = 0; Parameters != null && i < Parameters.Count; i++)
                {
                    result += Environment.NewLine;
                    result += (i == 0 ? " WHERE " : "   AND ") + Parameters[i].ParameterName.ToUpper() + " = @" + Parameters[i].ParameterName.ToUpper();
                }

                result += ";";
            }

            return result;
        }

        protected override String GenerateUpdateStatement(AbstractStoredData clazz)
        {
            String result = "";

            if (clazz != null)
            {
                result += "UPDATE " + clazz.GetType().Name.ToUpper() + Environment.NewLine + "SET    ";

                PropertyInfo[] properties = clazz.GetType().GetProperties();

                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    {
                        result += properties[i].Name.ToUpper() + " = @" + properties[i].Name.ToUpper() + "," + Environment.NewLine + "       ";

                        Parameters.AddNew("@" + properties[i].Name.ToUpper(), properties[i].PropertyType, properties[i].GetValue(clazz, null));
                    }
                }

                result += "DTMODIFIED = DATETIME('NOW')," + Environment.NewLine;
                result += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                result += "WHERE  ID = @ID;";

                Parameters.AddNew("@ID", typeof(Int32), clazz.Id);
            }

            return result;
        }

        protected override String GenerateDeleteStatement(AbstractStoredData clazz)
        {
            String result = "";

            if (clazz != null)
            {
                result += "DELETE" + Environment.NewLine;
                result += "FROM   " + clazz.GetType().Name + Environment.NewLine;
                result += "WHERE  ID = @ID;";

                Parameters.AddNew("@ID", typeof(Int32), clazz.Id);
            }

            return result;
        }

        protected override String GenerateInsertStatement(AbstractStoredData clazz)
        {
            String result = "";

            if (clazz != null)
            {
                result += "INSERT INTO " + clazz.GetType().Name.ToUpper() + " (ID";

                PropertyInfo[] properties = clazz.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    {
                        result += ", " + properties[i].Name.ToUpper();
                    }
                }

                result += ", DTCREATED, DTMODIFIED, ROWVER)" + Environment.NewLine + "VALUES (NULL, ";

                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    {
                        result += "@" + properties[i].Name.ToUpper() + ", ";

                        Parameters.AddNew("@" + properties[i].Name.ToUpper(), properties[i].PropertyType, properties[i].GetValue(clazz, null));
                    }                    
                }

                result += "DATETIME('NOW'), DATETIME('NOW'), 0);" + Environment.NewLine;
                result += "SELECT LAST_INSERT_ROWID() AS ID;";
            }

            return result;
        }

        #endregion
    }
}
