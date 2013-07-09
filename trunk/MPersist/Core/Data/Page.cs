using System;

namespace MPersist.Core.Data
{
    public class Page
    {
        private static Logger Log = Logger.GetInstance(typeof(Page));

        #region Variable Declarations

        private Int32 mPageNo_ = 0;
        private Boolean mIncludeRecordCount_ = true;
        private Int32 mTotalPageCount_ = 0;
        private Int32 mTotalRowCount_ = 0;
        private Int32 mRowsFetchedSoFar_ = 0;

        #endregion

        #region Properties

        public Int32 PageNo { get { return mPageNo_; } set { mPageNo_ = value; } }
        public Boolean IncludeRecordCount { get { return mIncludeRecordCount_; } set { mIncludeRecordCount_ = value; } }
        public Int32 TotalPageCount { get { return mTotalPageCount_; } set { mTotalPageCount_ = value; } }
        public Int32 TotalRowCount { get { return mTotalRowCount_; } set { mTotalRowCount_ = value; } }
        public Int32 RowsFetchedSoFar { get { return mRowsFetchedSoFar_; } set { mRowsFetchedSoFar_ = value; } }
        public Page NextPage { get { return HasNext ? new Page(PageNo + 1) : null; } }
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
    }
}
