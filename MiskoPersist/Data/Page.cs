using System;
using Newtonsoft.Json;
using MiskoPersist.Attributes;
using MiskoPersist.Core;

namespace MiskoPersist.Data
{
	[JsonObjectAttribute(MemberSerialization.OptOut)]
    public class Page : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(Page));

        #region Fields

        

        #endregion

        #region Properties

		public Int32 PageNo 
		{
			get;
			set;
		}
        
        public Boolean IncludeRecordCount 
        { 
        	get;
        	set;
        }
        
		public Int32 TotalPageCount 
		{
			get;
			set;
		}
		
		public Int32 TotalRowCount 
		{
			get;
			set;
		}
		
        public Int32 RowsFetchedSoFar 
        { 
        	get;
        	set;
        }
        
        [JsonIgnore]
        public Boolean HasNext 
        { 
        	get 
        	{ 
        		return PageNo < TotalPageCount; 
        	}
        }
        
        [JsonIgnore]
        public Page Next 
        { 
        	get 
        	{ 
        		return new Page(PageNo + 1); 
        	}
        }

        #endregion

        #region Constructors

        public Page()
        {
        	IncludeRecordCount = true;
        }

        public Page(Int32 page)
        	: this()
        {
            PageNo = page;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Int32 PageCount(Int32 pageSize)
        {
            if (TotalRowCount > 0 && pageSize > 0)
            {
                if (pageSize > 0)
                {
                    int r = TotalRowCount / pageSize;

                    if (TotalRowCount % pageSize > 0)
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
