using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;

namespace MPersist.Core.Message
{
    public abstract class MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageWrapper));

        #region Fields

        private readonly RequestMessage mRequest_;
        private readonly ResponseMessage mResponse_;

        #endregion

        #region Properties
        
        public RequestMessage Request { get { return mRequest_; } }
        public ResponseMessage Response { get { return mResponse_; } }

        #endregion

        #region Constructors

        public MessageWrapper()
        {
        }

        public MessageWrapper(RequestMessage request, ResponseMessage response)
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

    // Internal class to override the NameSpaces to be excluded from the XML
    internal class NoNamespaceXmlWriter : XmlTextWriter
    {
        public NoNamespaceXmlWriter(TextWriter output) : base(output) 
        { 
            Formatting = Formatting.Indented; 
        }

        public override void WriteStartDocument() 
        {
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }
}
