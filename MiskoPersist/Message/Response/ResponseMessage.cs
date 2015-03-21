using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Newtonsoft.Json;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoPersist.Message.Response
{
	[JsonObjectAttribute(MemberSerialization.OptOut)]
    public class ResponseMessage : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(ResponseMessage));

        #region Fields



        #endregion

        #region Properties

        public ErrorLevel Status { get; set; }
        public ErrorMessages Errors { get; set; }
        public ErrorMessages Infos { get; set; }
        public ErrorMessages Warnings { get; set; }
        public ErrorMessages Confirmations { get; set; }
        public Page Page { get; set; }
        [JsonIgnore]
        public Boolean HasErrors { get { return Errors != null && Errors.Count > 0; } }
        [JsonIgnore]
        public Boolean HasInfos { get { return Infos != null && Infos.Count > 0; } }
        [JsonIgnore]
        public Boolean HasWarnings { get { return Warnings != null && Warnings.Count > 0; } }
        [JsonIgnore]
        public Boolean HasConfirmations { get { return Confirmations != null && Confirmations.Count > 0; } }

        #endregion

        #region Constructors

        protected ResponseMessage()
        {
        }

        #endregion

        #region Private Properties

        private PropertyInfo[] GetProperties()
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();

            String[] filter = { "Status", "HasErrors", "Errors", "HasInfos", "Infos", "HasWarnings", "Warnings", "HasConfirmations", "Confirmations", "Page" };

            foreach (PropertyInfo item in GetType().GetProperties())
            {
                if (Array.IndexOf(filter, item.Name) < 0)
                {
                    properties.Add(item);
                }
            }

            return properties.ToArray();
        }

        #endregion
    }
}
