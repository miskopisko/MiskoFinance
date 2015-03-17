using System;
using MiskoPersist.Attributes;
using MiskoPersist.Core;

namespace MiskoPersist.Data
{
    public class Page : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(Page));

        #region Fields

        private Int32 mPageNo_ = 0;
        private Boolean mIncludeRecordCount_ = true;
        private Int32 mTotalPageCount_ = 0;
        private Int32 mTotalRowCount_ = 0;
        private Int32 mRowsFetchedSoFar_ = 0;

        #endregion

        #region Properties

        [Viewed]
        public Int32 PageNo { get { return mPageNo_; } set { mPageNo_ = value; } }
        [Viewed]
        public Boolean IncludeRecordCount { get { return mIncludeRecordCount_; } set { mIncludeRecordCount_ = value; } }
        [Viewed]
        public Int32 TotalPageCount { get { return mTotalPageCount_; } set { mTotalPageCount_ = value; } }
        [Viewed]
        public Int32 TotalRowCount { get { return mTotalRowCount_; } set { mTotalRowCount_ = value; } }
        [Viewed]
        public Int32 RowsFetchedSoFar { get { return mRowsFetchedSoFar_; } set { mRowsFetchedSoFar_ = value; } }
        [Viewed]
        public Boolean HasNext { get { return PageNo < TotalPageCount; } }

        #endregion

        #region Constructors

        public Page()
        {
        }

        public Page(Int32 page)
        {
            mPageNo_ = page;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Int32 PageCount(Int32 pageSize)
        {
            if (mTotalRowCount_ > 0 && pageSize > 0)
            {
                if (pageSize > 0)
                {
                    int r = mTotalRowCount_ / pageSize;

                    if (mTotalRowCount_ % pageSize > 0)
                    {
                        r = r + 1;
                    }

                    return r;
                }

                return 0;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Override Methods

        

        #endregion
    }
}
