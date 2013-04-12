using System;
using MPersist.Core.Data;
using MPersist.Core.Attributes;
using MPersist.Core;
using System.Windows.Forms;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTransaction : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTransaction));

        #region Variable Declarations

        

        #endregion

        #region Properties

        [Viewed]
        public DateTime Date { get ; set; }
        [Viewed]
        public String Description { get; set; }
        [Viewed]
        public Money Debit { get; set; }
        [Viewed]
        public Money Credit { get; set; }
        [Viewed]
        public String Category { get; set; }

        public DataGridViewRow DataRecord
        {
            get { return new DataGridViewRow(); }
        }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
