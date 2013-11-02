using System;
using System.Xml;
using MPersist.Attributes;
using MPersist.Core;

namespace MPersist.Data
{
    public class Page : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(Page));

        #region Fields

        private Int32 mPageNo_ = 0;
        private Int32 mNoRows_ = 20;
        private Boolean mIncludeRecordCount_ = false;
        private Int32 mTotalPageCount_ = 0;
        private Int32 mTotalRowCount_ = 0;
        private Int32 mRowsFetchedSoFar_ = 0;

        #endregion

        #region Properties

        [Viewed]
        public Int32 PageNo { get { return mPageNo_; } set { mPageNo_ = value; } }
        [Viewed]
        public Int32 NoRows { get { return mNoRows_; } set { mNoRows_ = value; } }
        [Viewed]
        public Boolean IncludeRecordCount { get { return mIncludeRecordCount_; } set { mIncludeRecordCount_ = value; } }
        [Viewed]
        public Int32 TotalPageCount { get { return mTotalPageCount_; } set { mTotalPageCount_ = value; } }
        [Viewed]
        public Int32 TotalRowCount { get { return mTotalRowCount_; } set { mTotalRowCount_ = value; mTotalPageCount_ = PageCount(); } }
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

        public Page(Int32 page, Int32 rows)
        {
            mPageNo_ = page;
            mNoRows_ = rows;
        }

        #endregion

        #region Private Methods

        private Int32 PageCount()
        {
            if (mTotalRowCount_ > 0 && mNoRows_ > 0)
            {
                if (mNoRows_ > 0)
                {
                    int r = mTotalRowCount_ / mNoRows_;

                    if (mTotalRowCount_ % mNoRows_ > 0)
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

        #region Public Methods

        

        #endregion

        #region Override Methods

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Page");

            writer.WriteElementString("PageNo",PageNo.ToString());
            writer.WriteElementString("NoRows",NoRows.ToString());            

            if (IncludeRecordCount)
            {
                writer.WriteElementString("IncludeRecordCount", IncludeRecordCount.ToString());
                writer.WriteElementString("TotalPageCount", TotalPageCount.ToString());
                writer.WriteElementString("TotalRowCount", TotalRowCount.ToString());
                writer.WriteElementString("RowsFetchedSoFar", RowsFetchedSoFar.ToString());
                writer.WriteElementString("HasNext", HasNext.ToString());
            }

            writer.WriteFullEndElement();
        }

        #endregion
    }
}
