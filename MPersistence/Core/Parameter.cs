using System;
using MPersist.Core;
using System.Data.Common;
using System.Data;

namespace MPersist.Core
{
    public class Parameter : DbParameter
    {
        private static Logger Log = Logger.GetInstance(typeof(Parameter));

        #region Variable Declarations



        #endregion

        #region Properties

        public override DbType DbType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override ParameterDirection Direction
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsNullable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override string ParameterName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void ResetDbType()
        {
            throw new NotImplementedException();
        }

        public override int Size
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override string SourceColumn
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool SourceColumnNullMapping
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override DataRowVersion SourceVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override object Value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Constructors

        public Parameter()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion

        
    }
}
