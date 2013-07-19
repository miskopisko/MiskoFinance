using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace MPersist.Core.Tools
{
    public class Utils
    {
        private static Logger Log = Logger.GetInstance(typeof(Utils));

        public static String GenerateHash(String input)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        public static String ResolveTextParameters(String text, Object[] parameters)
        {
            if (text != null)
            {
                String param = (String)text.Clone();

                Regex reg = new Regex("[{]([0-9]+|D-[LS]{1}:[0-9]+|N-[0-9]+,[0-9]+:[0-9]+)[}]");
                int[] groups = reg.GetGroupNumbers();

                Match match = reg.Match(param);
                int counter = 0;

                while (match.Success)
                {
                    if (groups.Length == 2)
                    {
                        CaptureCollection collect = match.Groups[groups[1]].Captures;
                        foreach (object t in collect)
                        {
                            if (Regex.IsMatch(param, "[{]" + counter + "[}]")) // Text
                            {
                                String paramVal = parameters != null && parameters[counter] != null ? parameters[counter].ToString() : "";
                                param = Regex.Replace(param, "[{]" + counter + "[}]", paramVal);
                            }

                            counter++;
                        }
                    }

                    match = match.NextMatch();
                }

                return param;
            }

            return "";
        }

        public static T Deserialize<T>(String xml)
        {
            if (String.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));

            return (T)serializer.Deserialize(xmlReader);
        }
    }
}
