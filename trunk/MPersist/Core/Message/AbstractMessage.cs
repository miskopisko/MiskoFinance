using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MPersist.Core.Message
{
    public abstract class AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractMessage));

        #region Variable Declarations

        private readonly AbstractRequest mRequest_;
        private readonly AbstractResponse mResponse_;

        #endregion

        #region Properties
        
        public AbstractRequest Request
        {
            get
            {
                return mRequest_;
            }
        }

        public AbstractResponse Response
        {
            get
            {
                return mResponse_;
            }
        }

        #endregion

        #region Constructors

        protected AbstractMessage()
        {

        }

        protected AbstractMessage(AbstractRequest request, AbstractResponse response)
        {
            mRequest_ = request;
            mResponse_ = response;
        }

        #endregion

        public String ToXml()
        {
            try
            {
                // Rig it so that there are no namespaces in the XML
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                StringBuilder builder = new StringBuilder();
                using (XmlWriter writer = new NoNamespaceXmlWriter(new StringWriter(builder)))
                {
                    XmlSerializer request = new XmlSerializer(Request.GetType());
                    request.Serialize(writer, Request, ns);

                    builder.Append(Environment.NewLine);

                    XmlSerializer response = new XmlSerializer(Response.GetType());
                    response.Serialize(writer, Response, ns);

                    return builder.ToString();
                }
            }
            catch (Exception)
            {
            }

            return "Error generating XML";
        }

        public abstract void Execute(Session session);
    }

    internal class NoNamespaceXmlWriter : XmlTextWriter
    {
        //Provide as many contructors as you need
        public NoNamespaceXmlWriter(TextWriter output)
            : base(output) { Formatting = Formatting.Indented; }

        public override void WriteStartDocument() { }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }
}
