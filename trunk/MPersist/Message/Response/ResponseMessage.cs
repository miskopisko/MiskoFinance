using System;
using System.Xml.Serialization;
using MPersist.Core;
using MPersist.Data;
using MPersist.Debug;
using MPersist.Enums;
using MPersist.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MPersist.Message.Response
{
    public class ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ResponseMessage));

        #region Fields



        #endregion

        #region Properties

        public ErrorMessages Errors { get; set; }
        public ErrorMessages Warnings { get; set; }
        public ErrorMessages Confirmations { get; set; }
        public Boolean HasErrors { get { return Errors != null && Errors.Count > 0; } set { return; } }
        public Boolean HasWarnings { get { return Warnings != null && Warnings.Count > 0; } set { return; } }
        public Boolean HasConfirmations { get { return Confirmations != null && Confirmations.Count > 0; } set { return; } }
        public MessageMode MessageMode { get; set; }
        public Page Page { get; set; }
        public MessageTiming MessageTiming { get; set; }

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

        protected ResponseMessage()
        {
        }

        #endregion
    }
}
