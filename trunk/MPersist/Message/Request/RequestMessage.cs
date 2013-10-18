using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;

namespace MPersist.Message.Request
{
    public class RequestMessage : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(RequestMessage));

        #region Fields

        private MessageMode mMessageMode_ = MessageMode.Normal;
        private String mCommand_ = "Execute";
        private String mConnection_ = "Default";
        private Int32 mPage_ = 0;
        private Int32 mRowsPerPage_ = 20;
        private ErrorMessages mConfirmations_ = new ErrorMessages();

        #endregion

        #region Properties

        public MessageMode MessageMode { get { return mMessageMode_; } set { mMessageMode_ = value; } }
        public String Command { get { return mCommand_; } set { mCommand_ = value; } }
        public String Connection { get { return mConnection_; } set { mConnection_ = value; } }
        public Int32 Page { get { return mPage_; } set { mPage_ = value; } }
        public Int32 RowsPerPage { get { return mRowsPerPage_; } set { mRowsPerPage_ = value; } }
        public ErrorMessages Confirmations { get { return mConfirmations_; } set { mConfirmations_ = value; } }

        #endregion

        #region Constructors

        protected RequestMessage()
        {
        }

        #endregion

        #region XML Serialization

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);

            writer.WriteElementString("MessageMode", MessageMode.Value.ToString());
            writer.WriteElementString("Command", Command);
            writer.WriteElementString("Connection", Connection);

            if (Page > 0)
            {
                writer.WriteElementString("Page", Page.ToString());
            }

            writer.WriteElementString("RowsPerPage", RowsPerPage.ToString());

            if (Confirmations.Count > 0)
            {
                Confirmations.WriteXml(writer, "Confirmations");
            }

            WriteXmlProperties(writer, GetProperties());
        }

        #endregion

        #region Private Properties

        private PropertyInfo[] GetProperties()
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();

            String[] filter = { "MessageMode", "Command", "Connection", "Page", "RowsPerPage", "Confirmations" };

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
