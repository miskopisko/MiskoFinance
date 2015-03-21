using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoPersist.Message.Request
{
    public class RequestMessage : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(RequestMessage));

        #region Fields

        //private MessageMode mMessageMode_ = MessageMode.Normal;
        //private String mCommand_ = "Execute";
        //private String mConnection_ = "Default";
        //private Page mPage_ = new Page(0);

        #endregion

        #region Properties

        public MessageMode MessageMode 
        { 
        	get;
        	set; 
        }
        
        public String Command 
        { 
        	get;
        	set; 
        }
        
        public String Connection 
        { 
        	get;
        	set; 
        }
        
        public Page Page 
        { 
        	get;
        	set; 
        }

        #endregion

        #region Constructors

        protected RequestMessage()
        {
        }

        #endregion

        #region Private Properties

        
        
        #endregion
    }
}
