using System;
using MPersist.Core;
using MPersist.Core.Data;
using System.Data.Common;
using System.Collections.Generic;

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
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion

        public override void GenerateSelectStatement(Type clazz, Parameters parameters)
        {
            throw new NotImplementedException();
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
