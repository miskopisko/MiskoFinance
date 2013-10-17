using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;

namespace MPersist.Message.Response
{
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
        public Boolean HasErrors { get { return Errors != null && Errors.Count > 0; } }
        public Boolean HasInfos { get { return Infos != null && Infos.Count > 0; } }
        public Boolean HasWarnings { get { return Warnings != null && Warnings.Count > 0; } }
        public Boolean HasConfirmations { get { return Confirmations != null && Confirmations.Count > 0; } }
        public Page Page { get; set; }

        #endregion

        #region Constructors

        protected ResponseMessage()
        {
        }

        #endregion

        #region XML Serialization

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
         
            writer.WriteElementString("Status", Status.Value.ToString());
            writer.WriteElementString("HasErrors", HasErrors.ToString());
            writer.WriteElementString("HasInfos", HasInfos.ToString());
            writer.WriteElementString("HasWarnings", HasWarnings.ToString());
            writer.WriteElementString("HasConfirmations", HasConfirmations.ToString());

            if (HasErrors)
            {
                Errors.WriteXml(writer, "Errors");
            }

            if (HasInfos)
            {
                Infos.WriteXml(writer, "Infos");
            }

            if (HasWarnings)
            {
                Warnings.WriteXml(writer, "Warnings");
            }

            if (HasConfirmations)
            {
                Confirmations.WriteXml(writer, "Confirmations");
            }

            WriteXmlProperties(writer, GetProperties());

            if (Page != null && Page.PageNo > 0)
            {
                writer.WriteStartElement("Page");
                Page.WriteXml(writer);
                writer.WriteFullEndElement();
            }
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
