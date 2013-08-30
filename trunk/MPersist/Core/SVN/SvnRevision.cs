using System;

namespace MPersist.Core.SVN
{
    public class SvnRevision : IComparable
    {
        private static readonly Logger Log = Logger.GetInstance(typeof(SvnRevision));

        #region Global Constants

        public static readonly SvnRevision HEAD = new SvnRevision(-1000);
        public static readonly SvnRevision BASE = new SvnRevision(-1001);
        public static readonly SvnRevision COMMITTED = new SvnRevision(-1002);
        public static readonly SvnRevision PREV = new SvnRevision(-1003);

        #endregion

        #region Fields

        private Int32 mRevision_;

        #endregion

        #region Properties

        public Int32 Revision { get { return mRevision_; } }
        public SvnRevision Previous { get { return new SvnRevision(mRevision_ - 1); } }

        #endregion

        #region Constructor

        public SvnRevision(Int32 revision)
        {
            mRevision_ = revision;
        }

        public SvnRevision(String revision)
        {
            mRevision_ = Convert.ToInt32(revision);
        }

        #endregion

        #region Public Methods

        

        #endregion

        #region Override Methods

        public override string ToString()
        {
            if (this.Equals(SvnRevision.HEAD))
            {
                return "HEAD";
            }
            else if (this.Equals(SvnRevision.BASE))
            {
                return "BASE";
            }
            else if (this.Equals(SvnRevision.COMMITTED))
            {
                return "COMMITTED";
            }
            else if (this.Equals(SvnRevision.PREV))
            {
                return "PREV";
            }
            else
            {
                return mRevision_.ToString();
            }
        }

        #endregion

        #region IComparable Implementation

        public int CompareTo(object obj)
        {
            if (obj is SvnRevision)
            {
                return ((SvnRevision)obj).Revision.CompareTo(this.Revision);
            }
            return -1;
        }

        #endregion
    }
}