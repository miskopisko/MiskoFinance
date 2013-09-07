using System;
using System.Xml.Serialization;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;
using MPersist.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MPersist.Message.Request
{
    public class RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(RequestMessage));

        #region Fields

        private MessageMode mMessageMode_ = MessageMode.Normal;
        private String mCommand_ = "Execute";
        private String mConnection_ = "Default";
        private Page mPage_ = new Page();

        #endregion

        #region Properties

        public MessageMode MessageMode { get { return mMessageMode_; } set { return; } }
        public String Command { get { return mCommand_; } set { return; } }
        public String Connection { get { return mConnection_; } set { mConnection_ = value; } }
        public Page Page { get { return mPage_; } set { return; } }

        [JsonIgnore]
        [XmlIgnore]
        public String XML { get { return Utils.Serialize(this); } }
        [JsonIgnore]
        [XmlIgnore]
        public String JSON 
        { 
            get 
            { 
                return JsonConvert.SerializeObject(this, 
                            Newtonsoft.Json.Formatting.Indented, 
                            new JsonSerializerSettings 
                            { 
                                Error = delegate(object sender, ErrorEventArgs args)
                                    {
                                        //errors.Add(args.ErrorContext.Error.Message);
                                        args.ErrorContext.Handled = true;
                                    }
                            }
                            ); 
            } 
        }

        #endregion

        #region Constructors

        public RequestMessage()
        {
        }

        #endregion
    }
}
