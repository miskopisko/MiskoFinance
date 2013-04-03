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

        public override DbType DbType { get; set; }

        public override ParameterDirection Direction { get; set; }

        public override bool IsNullable { get; set; }

        public override string ParameterName { get; set; }        

        public override int Size { get; set; }

        public override string SourceColumn { get; set; }

        public override bool SourceColumnNullMapping { get; set; }

        public override DataRowVersion SourceVersion { get; set; }

        public override object Value { get; set; }

        #endregion

        #region Constructors

        public Parameter(String parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public override void ResetDbType()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
