using System;
using MPersist.Core;
using MPersist.Core.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Data.Common;

namespace MPersistence.Core.Persistences
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



        #endregion

        public override void GenerateSelectStatement(Type clazz, Parameters parameters)
        {
            if (clazz != null)
            {
                SQL += "SELECT ";
                List<String> columns = new List<String>();

                columns.Add(clazz.Name.ToUpper() + "ID");

                foreach (PropertyInfo property in clazz.GetProperties())
                {
                    columns.Add(property.Name.ToUpper());
                }

                for (Int32 i = 0; i < columns.Count; i++)
                {
                    SQL += columns[i] + (i + 1 < columns.Count ? ", " : "");
                }

                SQL += " FROM " + clazz.Name.ToUpper();

                String where = ""; Int32 where_item_ctr = 0;

                for (Int32 i = 0; parameters != null && i < parameters.Count; i++)
                {
                    where += (where_item_ctr == 0 ? " WHERE " : " AND ") + parameters[i].ParameterName + "` = ?";
                    where_item_ctr++;
                }

                SQL += where;
            }
        }

        public override void GenerateUpdateStatement(Type clazz, Parameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void GenerateDeleteStatement(Type clazz, Parameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void GenerateInsertStatement(Type clazz)
        {
            throw new NotImplementedException();
        }
    }
}
