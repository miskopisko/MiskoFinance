using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;

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

        protected override void SetParameters(Object[] values)
        {
            // Normalize the parameters by replacing typical ? marks with @param values
            Int32 end = 0;
            Int32 position = 0;
            while ((end = command_.CommandText.IndexOf("?")) > 0)
            {
                command_.CommandText = command_.CommandText.Substring(0, end) + ("@param" + position++) + command_.CommandText.Substring(end + 1);
                end = -1;
            }

            position = 0;
            foreach (Object item in values)
            {
                SQLiteParameter param = new SQLiteParameter();
                param.ParameterName = "@param" + position;

                if (item == null)
                {
                    param.IsNullable = true;
                    param.Value = DBNull.Value;
                    command_.Parameters.Add(param);
                }
                else if (item is AbstractStoredData)
                {
                    param.IsNullable = false;
                    param.DbType = DbType.Int32;
                    param.Value = item != null ? (Object)((AbstractStoredData)item).Id : DBNull.Value;
                    command_.Parameters.Add(param);
                }
                else if (item is AbstractEnum)
                {
                    param.IsNullable = true;
                    param.DbType = DbType.Int32;
                    param.Value = ((AbstractEnum)item).IsSet ? (Object)((AbstractEnum)item).Value : DBNull.Value;
                    command_.Parameters.Add(param);
                }
                else if (item is Array)
                {
                    String firstHalf = command_.CommandText.Substring(0, command_.CommandText.IndexOf(param.ParameterName));
                    String secondHalf = command_.CommandText.Substring(command_.CommandText.IndexOf(param.ParameterName) + 7);
                    String middle = "";

                    foreach (Object o in ((Array)item))
                    {
                        SQLiteParameter innerParam = new SQLiteParameter();
                        innerParam.ParameterName = "@param" + position;
                        innerParam.Value = o;
                        middle += innerParam.ParameterName + ", ";
                        command_.Parameters.Add(innerParam);
                        position++;
                    }

                    command_.CommandText = firstHalf + middle.Substring(0, middle.Length - 2) + secondHalf;
                }
                else if (item is Money)
                {
                    param.DbType = DbType.Decimal;
                    param.Value = ((Money)item).ToDecimal(null);
                    command_.Parameters.Add(param);
                }
                else
                {
                    param.Value = item;
                    command_.Parameters.Add(param);
                }

                position++;
            }
        }

        protected override void GenerateUpdateStatement(AbstractStoredData clazz)
        {
            String result = "";
            List<Object> values = new List<Object>();

            if (clazz != null)
            {
                result += "UPDATE " + clazz.GetType().Name.ToUpper() + Environment.NewLine + "SET    ";

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(clazz.GetType(), new Attribute[] { new StoredAttribute() });

                for (int i = 0; i < properties.Count; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase) && !properties[i].Name.Equals("ROWVER", StringComparison.OrdinalIgnoreCase))
                    {
                        result += properties[i].Name.ToUpper() + " = ?, " + Environment.NewLine + "       ";
                        values.Add(properties[i].GetValue(clazz));
                    }
                }

                result += "DTMODIFIED = DATETIME('NOW')," + Environment.NewLine;
                result += "       ROWVER = ROWVER + 1" + Environment.NewLine;
                result += "WHERE  ID = ?" + Environment.NewLine;
                result += "AND    ROWVER = ?;";

                values.Add(clazz.Id);
                values.Add(clazz.RowVer);

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
                result += "WHERE  ID = ?" + Environment.NewLine;
                result += "AND    ROWVER = ?;";

                values.Add(-clazz.Id);
                values.Add(clazz.RowVer);

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

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(clazz.GetType(), new Attribute[] { new StoredAttribute() });

                for (int i = 0; i < properties.Count; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase) && !properties[i].Name.Equals("ROWVER", StringComparison.OrdinalIgnoreCase))
                    {
                        result += ", " + properties[i].Name.ToUpper();
                    }
                }

                result += ", DTCREATED, DTMODIFIED, ROWVER)" + Environment.NewLine + "VALUES (NULL, ";

                for (int i = 0; i < properties.Count; i++)
                {
                    if (!properties[i].Name.Equals("ID", StringComparison.OrdinalIgnoreCase) && !properties[i].Name.Equals("ROWVER", StringComparison.OrdinalIgnoreCase))
                    {
                        result += "?, ";
                        values.Add(properties[i].GetValue(clazz));
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
