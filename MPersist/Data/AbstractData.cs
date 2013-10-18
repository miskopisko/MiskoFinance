using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MPersist.Attributes;
using MPersist.Core;
using MPersist.Enums;
using MPersist.MoneyType;

namespace MPersist.Data
{
    public class AbstractData : IXmlSerializable
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractData));

        #region Constants

        public const String ENCODING = "ISO-8859-1";
        private const String NAMESPACE = "";

        #endregion

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public AbstractData()
        {
        }

        public AbstractData(Session session, Persistence persistence)
        {
            Set(session, persistence);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public AbstractData Set(Session session, Persistence persistence)
        {
            return Set(session, persistence, false);
        }

        public AbstractData Set(Session session, Persistence persistence, bool deep)
        {
            if (persistence.Next())
            {
                PropertyInfo[] properties = null;
                if(this is AbstractStoredData)
                {
                    properties = GetStoredProperties();

                    ((AbstractStoredData)this).IsSet = true;
                    ((AbstractStoredData)this).Id = persistence.GetPrimaryKey("Id");
                    ((AbstractStoredData)this).RowVer = persistence.GetLong("RowVer").HasValue ? persistence.GetLong("RowVer").Value : 0;
                }
                else if(this is AbstractViewedData)
                {
                    properties = GetViewedProperties();
                }

                foreach (PropertyInfo property in properties)
                {
                    String columnName = GetColumnName(property);

                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(this, persistence.GetString(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        Boolean? value = persistence.GetBoolean(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : false, null);
                    }
                    else if (property.PropertyType == typeof(Boolean?))
                    {
                        property.SetValue(this, persistence.GetBoolean(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        Int32? value = persistence.GetInt(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Int32?))
                    {
                        property.SetValue(this, persistence.GetInt(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        Int64? value = persistence.GetLong(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Int64?))
                    {
                        property.SetValue(this, persistence.GetLong(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        Double? value = persistence.GetDouble(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Double?))
                    {
                        property.SetValue(this, persistence.GetDouble(columnName), null);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime? value = persistence.GetDate(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue, null);
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(this, persistence.GetDate(columnName), null);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)))
                    {
                        AbstractEnum item = null;

                        if (persistence.GetLong(columnName) != null && persistence.GetLong(columnName).HasValue)
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { persistence.GetLong(columnName) });
                        }
                        else if (persistence.GetString(columnName) != null)
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { persistence.GetString(columnName) });
                        }
                        else
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { -1 });
                        }

                        property.SetValue(this, item, null);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                    {
                        AbstractStoredData item = null;

                        if (persistence.GetInt(columnName) > 0)
                        {
                            item = (AbstractStoredData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            item.Id = persistence.GetPrimaryKey(columnName);
                        }

                        property.SetValue(this, item, null);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(this, new Guid(persistence.GetString(columnName)), null);
                    }
                    else if (property.PropertyType == typeof(Money))
                    {
                        property.SetValue(this, persistence.GetMoney(columnName), null);
                    }
                    else if (property.PropertyType == typeof(PrimaryKey))
                    {
                        property.SetValue(this, persistence.GetPrimaryKey(columnName), null);
                    }

                    if (deep)
                    {
                        FetchDeep(session);
                    }
                }
            }

            return this;
        }

        public void FetchDeep(Session session)
        {
            foreach (PropertyInfo property in GetStoredProperties(GetType()))
            {
                if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                {
                    AbstractStoredData item = (AbstractStoredData)property.GetValue(this, null);
                    if (item != null && item.Id > 0 && item.IsNotSet)
                    {
                        item.FetchById(session, item.Id, true);
                    }
                }
            }
        }

        #endregion

        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            String myRoot = "";
            Boolean isComplete = false;
            Boolean inEmbededSimpleTypeSameName = false;

            while (!isComplete)
            {
                reader.MoveToContent();

                if (reader.NodeType == XmlNodeType.Element)
                {
                    String element = reader.Name;

                    if (String.IsNullOrEmpty(myRoot))
                    {
                        myRoot = reader.Name;
                        reader.Read();
                    }
                    else
                    {
                        if (ReadXmlElement(element, reader))
                        {
                            reader.MoveToContent();
                        }
                        else
                        {
                            DiscardXml(element, reader); // Consume the Element (including its children) as it has not been processed because it is not known.
                        }

                        if (element.Equals(myRoot) && reader.NodeType == XmlNodeType.EndElement)
                        {
                            inEmbededSimpleTypeSameName = true;
                        }
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    String element = reader.Name;

                    if (element.Equals(myRoot))
                    {
                        if (inEmbededSimpleTypeSameName)
                        {
                            inEmbededSimpleTypeSameName = false;
                        }
                        else
                        {
                            isComplete = true;
                        }
                    }

                    reader.Read();
                }
            }
        }

        public virtual void WriteXml(XmlWriter writer)
        {
        }

        protected internal virtual Boolean ReadXmlElement(String name, XmlReader reader)
        {
            PropertyInfo property = GetType().GetProperty(name);

            if (property != null && property.GetSetMethod() != null)
            {
                if (property.PropertyType == typeof(String))
                {
                    String value = ReadXmlString(reader);
                    property.SetValue(this, value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(Boolean) || property.PropertyType == typeof(Boolean?))
                {
                    Boolean? value = ReadXmlBool(reader);
                    property.SetValue(this, value.Value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(Int32) || property.PropertyType == typeof(Int32?))
                {
                    Int32? value = ReadXmlInt(reader);
                    property.SetValue(this, value.Value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(Int64) || property.PropertyType == typeof(Int64?))
                {
                    Int64? value = ReadXmlLong(reader);
                    property.SetValue(this, value.Value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(Double) || property.PropertyType == typeof(Double?))
                {
                    Double? value = ReadXmlDouble(reader);
                    property.SetValue(this, value.Value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    String value = ReadXmlString(reader);
                    property.SetValue(this, Convert.ToDateTime(value), null);
                    return true;
                }
                else if (property.PropertyType == typeof(PrimaryKey))
                {
                    Int64? value = ReadXmlLong(reader);
                    if (value.HasValue)
                    {
                        property.SetValue(this, new PrimaryKey(value.Value), null);
                    }
                    else
                    {
                        property.SetValue(this, null, null);
                    }
                    return true;
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    String value = ReadXmlString(reader);
                    property.SetValue(this, new Guid(value), null);
                    return true;
                }
                else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)))
                {
                    AbstractEnum value = null;
                    Int64? longVlaue = ReadXmlLong(reader);
                    String stringValue = ReadXmlString(reader);

                    if (longVlaue.HasValue)
                    {
                        value = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { longVlaue.Value });
                    }
                    else if (!String.IsNullOrEmpty(stringValue))
                    {
                        value = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { stringValue });
                    }
                    else
                    {
                        value = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { -1 });
                    }

                    property.SetValue(this, value, null);
                    return true;
                }
                else if (property.PropertyType == typeof(Money))
                {
                    Double? value = ReadXmlDouble(reader);
                    property.SetValue(this, new Money(Convert.ToDecimal(value.Value)), null);
                    return true;
                }
                else if (property.PropertyType == typeof(Page))
                {
                    Page value = new Page();
                    property.SetValue(this, value, null);
                    value.ReadXml(reader);
                    return true;
                }
                else if (property.PropertyType.BaseType == typeof(AbstractViewedData))
                {
                    AbstractViewedData value = (AbstractViewedData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                    property.SetValue(this, value, null);
                    value.ReadXml(reader);
                    return true;
                }
                else if (property.PropertyType.BaseType.IsGenericType && property.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(AbstractViewedDataList<>))
                {
                    Object value = property.GetValue(this, null);

                    if (value == null)
                    {
                        value = property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                        property.SetValue(this, value, null);
                    }

                    Type itemType = property.PropertyType.BaseType.GetGenericArguments()[0];
                    AbstractViewedData instance = (AbstractViewedData)itemType.Assembly.CreateInstance(itemType.FullName);
                    instance.ReadXml(reader);

                    value.GetType().InvokeMember("Add", BindingFlags.Default | BindingFlags.InvokeMethod, null, value, new Object[] { instance });
                    return true;
                }
                else if (property.PropertyType == typeof(ErrorMessages))
                {
                    ErrorMessages value = (ErrorMessages)property.GetValue(this, null);

                    if (value == null)
                    {
                        value = (ErrorMessages)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                        property.SetValue(this, value, null);
                    }

                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.ReadXml(reader);

                    value.Add(errorMessage);
                    return true;
                }
            }

            return false;
        }

        protected internal void DiscardXml(String name, XmlReader reader)
        {
            Boolean isComplete = false;
            Boolean embededComplexSameName = false;

            if (reader.NodeType == XmlNodeType.Element)
            {
                reader.Read();
            }

            while (!isComplete)
            {
                reader.MoveToContent();

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals(name))
                    {
                        embededComplexSameName = true;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    String element = reader.Name;

                    if (element.Equals(name))
                    {
                        if (embededComplexSameName)
                        {
                            embededComplexSameName = false;
                        }
                        else
                        {
                            isComplete = true;
                        }
                    }
                }

                reader.Read();
            }
        }

        protected internal void WriteXmlProperties(XmlWriter writer, PropertyInfo[] properties)
        {
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(this, null) != null)
                {
                    Object value = property.GetValue(this, null);

                    if (property.PropertyType == typeof(String) && !String.IsNullOrEmpty((String)value))
                    {
                        writer.WriteElementString(property.Name, ((String)value).Replace("\r", ""));
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        writer.WriteElementString(property.Name, ((Boolean)value).ToString());
                    }
                    else if (property.PropertyType == typeof(Boolean?) && ((Boolean?)value).HasValue)
                    {
                        writer.WriteElementString(property.Name, ((Boolean?)value).Value.ToString());
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        writer.WriteElementString(property.Name, ((Int32)value).ToString());
                    }
                    else if (property.PropertyType == typeof(Int32?) && ((Int32?)value).HasValue)
                    {
                        writer.WriteElementString(property.Name, ((Int32?)value).Value.ToString());
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        writer.WriteElementString(property.Name, ((Int64)value).ToString());
                    }
                    else if (property.PropertyType == typeof(Int64?) && ((Int64?)value).HasValue)
                    {
                        writer.WriteElementString(property.Name, ((Int64?)value).Value.ToString());
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        writer.WriteElementString(property.Name, ((Double)value).ToString());
                    }
                    else if (property.PropertyType == typeof(Double?) && ((Double?)value).HasValue)
                    {
                        writer.WriteElementString(property.Name, ((Double?)value).ToString());
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        writer.WriteElementString(property.Name, ((DateTime)value).ToShortDateString());
                    }
                    else if (property.PropertyType == typeof(DateTime?) && ((DateTime?)value).HasValue)
                    {
                        writer.WriteElementString(property.Name, ((DateTime)value).ToShortDateString());
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)) && ((AbstractEnum)value).IsSet)
                    {
                        writer.WriteElementString(property.Name, ((AbstractEnum)value).Value.ToString());
                    }
                    else if (property.PropertyType.BaseType == typeof(AbstractViewedData))
                    {
                        writer.WriteStartElement(property.Name);
                        ((AbstractViewedData)value).WriteXml(writer);
                        writer.WriteFullEndElement();
                    }
                    else if (property.PropertyType.BaseType.IsGenericType && property.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(AbstractViewedDataList<>))
                    {
                        property.PropertyType.GetMethod("WriteXml").Invoke(value, new Object[] { writer, property.Name });
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        writer.WriteElementString(property.Name, ((Guid)value).ToString());
                    }
                    else if (property.PropertyType == typeof(Money))
                    {
                        writer.WriteStartElement(property.Name);
                        ((Money)value).WriteXml(writer);
                        writer.WriteFullEndElement();
                    }
                    else if (property.PropertyType == typeof(PrimaryKey))
                    {
                        writer.WriteElementString(property.Name, ((PrimaryKey)value).ToString());
                    }
                    else if (property.PropertyType == typeof(FileInfo))
                    {
                        writer.WriteElementString(property.Name, ((FileInfo)value).ToString());
                    }
                }
            }
        }

        #endregion

        #region Protected Internal Methods

        protected internal String GetColumnName(PropertyInfo property)
        {
            foreach (Attribute attribute in property.GetCustomAttributes(false))
            {
                if (attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql && !String.IsNullOrEmpty(((StoredAttribute)attribute).ColumnName))
                {
                    return ((StoredAttribute)attribute).ColumnName;
                }

                if (attribute is ViewedAttribute && !String.IsNullOrEmpty(((ViewedAttribute)attribute).ColumnName))
                {
                    return ((ViewedAttribute)attribute).ColumnName;
                }
            }

            return property.Name;
        }

        protected internal PropertyInfo[] GetStoredProperties()
        {
            PropertyInfo[] properties = GetType().GetProperties();

            List<PropertyInfo> storedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql)
                    {
                        storedProperties.Add(property);
                    }
                }
            }

            return storedProperties.ToArray();
        }

        protected internal PropertyInfo[] GetStoredProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            List<PropertyInfo> storedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql)
                    {
                        storedProperties.Add(property);
                    }
                }
            }

            return storedProperties.ToArray();
        }

        protected internal PropertyInfo[] GetViewedProperties()
        {
            PropertyInfo[] properties = GetType().GetProperties();

            List<PropertyInfo> viewedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is ViewedAttribute)
                    {
                        viewedProperties.Add(property);
                    }
                }
            }

            return viewedProperties.ToArray();
        }

        #endregion

        #region XML Parsing Methods

        protected internal Int16? ReadXmlShort(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Int16.Parse(value); }
                catch { }
            }

            return null;
        }

        protected internal Int32? ReadXmlInt(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Int32.Parse(value); }
                catch { }
            }

            return null;
        }

        protected internal Int64? ReadXmlLong(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Int64.Parse(value); }
                catch { }
            }

            return null;
        }

        protected internal Double? ReadXmlDouble(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Double.Parse(value, CultureInfo.InvariantCulture.NumberFormat); }
                catch { }
            }

            return null;
        }

        protected internal Decimal? ReadXmlDecimal(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Decimal.Parse(value, CultureInfo.InvariantCulture.NumberFormat); }
                catch { }
            }

            return null;
        }

        protected internal Boolean? ReadXmlBool(XmlReader reader)
        {
            String value = ReadXmlString(reader);
            if (value != null)
            {
                try { return Boolean.Parse(value); }
                catch { }
            }

            return null;
        }

        protected internal String ReadXmlString(XmlReader reader)
        {
            String returnValue = null;

            if (reader != null && reader.NodeType == XmlNodeType.Element)
            {
                while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read(); // Read until there is data
                }

                returnValue = reader.Value;
                reader.Read(); // Move past the text
                reader.MoveToContent(); // Move until the next content element
            }

            return returnValue;
        }

        #endregion

        #region XML Serialization

        public static String Serialize(AbstractData obj)
        {
            String xmlized = "";

            XmlTextWriter writer = null;

            if (obj != null)
            {
                try
                {
                    writer = new XmlTextWriter(new MemoryStream(), Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartDocument();
                    writer.WriteStartElement(obj.GetType().Name, NAMESPACE);
                    obj.WriteXml(writer);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Flush();

                    Char[] characters = (new UTF8Encoding()).GetString(((MemoryStream)writer.BaseStream).ToArray()).ToCharArray();

                    StringBuilder buffer = new StringBuilder();

                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (characters[i] != 65279)
                        {
                            buffer.Append(characters[i]);
                        }
                    }

                    xmlized = buffer.ToString();
                }
                catch(Exception e)
                {
                    xmlized = "";
                }
                finally
                {
                    if (writer != null)
                    {
                        try
                        {
                            writer.Close();
                            writer = null;
                        }
                        catch { }
                    }
                }
            }

            return xmlized;
        }

        public static AbstractData Deserialize(String asXML, Type type)
        {
            AbstractData obj = null;

            if (type != null && !String.IsNullOrEmpty(asXML))
            {
                XmlReader reader = XmlReader.Create(new StringReader(asXML.Trim()));
                try
                {
                    obj = (AbstractData)type.GetConstructor(new Type[] { }).Invoke(new Object[] { });
                    obj.ReadXml(reader);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                }
            }

            return obj;
        }

        #endregion
    }
}
