using System.Collections.Generic;
using System.Xml;

namespace ProjectTemplate.Common
{
    public class XmlHelper
    {
        public XmlDocument XmlDoc { get; set; } = new XmlDocument();

        public XmlHelper(string text)
        {
            XmlDoc.LoadXml(text);
        }

        public XmlHelper(Xml xml)
        {
            XmlDeclaration dec = XmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlDoc.AppendChild(dec);
            XmlDoc.AppendChild(CreateXmlNode(xml));
        }

        public string GetXml()
        {
            return XmlDoc.InnerXml;
        }

        private XmlNode CreateXmlNode(Xml xml)
        {
            var ele = XmlDoc.CreateElement(xml.Key);
            if (xml.Xmls != null && xml.Xmls.Count != 0)
            {
                foreach (Xml x in xml.Xmls)
                {
                    ele.AppendChild(CreateXmlNode(x));
                }
            }
            else
            {
                if (xml.IsCData)
                {
                    XmlCDataSection cd = XmlDoc.CreateCDataSection(xml.Value);
                    ele.AppendChild(cd);
                }
                else
                {
                    ele.InnerText = xml.Value;
                }
            }
            return ele;
        }

        public void SetValue(string path, string value)
        {
            XmlNode node = XmlDoc.SelectSingleNode(path);
            if (node == null)
            {
                return;
            }
            XmlCDataSection cData = node.FirstChild as XmlCDataSection;
            if (cData == null)
            {
                node.Value = value;
            }
            else
            {
                cData.Value = value;
            }
        }

        public string GetValue(string path)
        {
            XmlNode node = XmlDoc.SelectSingleNode(path);
            XmlCDataSection cData = node?.FirstChild as XmlCDataSection;
            if (cData != null)
            {
                return cData.Value;
            }
            else
            {
                return node?.InnerText;
            }
        }

        public string GetValue(string path, string attr)
        {
            XmlNode node = XmlDoc.SelectSingleNode(path);
            return node.Attributes[attr].Value;
        }

        public string GetValue(string path, string attr, int index)
        {
            XmlNode node = XmlDoc.SelectNodes(path)[index];
            return node.Attributes[attr].Value;
        }
    }

    public class Xml
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public bool IsCData { get; set; }

        public List<Xml> Xmls { get; set; }
    }

}