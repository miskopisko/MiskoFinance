using System;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;
using System.Collections.Generic;

namespace MPersist.Core.Persistences
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
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override void SetParameters(Object[] value)
        {
            // Normalize the parameters by replacing typical ? marks with @param values
            Int32 end = 0;
            Int32 position = 0;
            while ((end = command_.CommandText.IndexOf("?")) > 0)
            {
                command_.CommandText = command_.CommandText.Substring(0, end) + ("@param" + position++) + command_.CommandText.Substring(end + 1);
                end = -1;
            }

            int cnt = 0;
            foreach (Object item in value)
            {
                if (item is AbstractStoredData)
                {
                    ((SQLiteCommand)command_).Parameters.AddWithValue("@param" + cnt, ((AbstractStoredData)item).Id);
                }
                else
                {
                    ((SQLiteCommand)command_).Parameters.AddWithValue("@param" + cnt, item != null ? item : DBNull.Value);
                }
                cnt++;
            }
        }

        protected override void GenerateUpdateStatement(AbstractStoredData clazz)
        {
            String result = "";
            List<Object> values = new List<Object>();

            if (clazz != null)
            {
                result += "UPDATE " + clazz.GetType().Name.ToUpper() + Environment.NewLine + "SET    ";

                PropertyInfo[] properties = clazz.GetType().GetProperties();

                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    {
                        result += properties[i].Name.ToUpper() + " = ?, " + Environment.NewLine + "       ";
                        values.Add(properties[i].GetValue(clazz, null));
                    }
                }

                result += "DTMODIFIED = DATETIME('NOW')," + Environment.NewLine;
                result += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                result += "WHERE  ID = ?;";

                values.Add(clazz.Id);

                command_.CommandText = result;
                SetParameters(values.ToArray());
            }
        }

        protected override void GenerateDeleteStatement(AbstractStoredData clazz)
        {
            String result = "";
            List<Object> values = new List<Object>();

            if (clazz != null)
            {
                result += "DELETE" + Environment.NewLine;
                result += "FROM   " + clazz.GetType().Name + Environment.NewLine;
                result += "WHERE  ID = ?;";

                values.Add(clazz.Id);

                command_.CommandText = result;
                SetParameters(values.ToArray());
            }
        }

        protected override void GenerateInsertStatement(AbstractStoredData clazz)
        {
            String result = "";
            List<Object> values = new List<Object>();

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
                        result += "?, ";
                        values.Add(properties[i].GetValue(clazz, null));
                    }                    
                }

                result += "DATETIME('NOW'), DATETIME('NOW'), 0);" + Environment.NewLine;
                result += "SELECT LAST_INSERT_ROWID() AS ID;";
            }

            command_.CommandText = result;
            SetParameters(values.ToArray());
        }

        #endregion
    }
}
