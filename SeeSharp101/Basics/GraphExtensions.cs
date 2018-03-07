using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace SeeSharp101.Basics
{
    public static class GraphExtensions
    {
        public static XmlDocument GetStatisticsXml(this Graph graph)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //Declaration    

            XmlDeclaration xmlDec;
            xmlDec = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(xmlDec);

            //Root node with attribute     
            XmlNode rootNode = xmlDoc.CreateElement("graph");
            XmlAttribute connAttribute = xmlDoc.CreateAttribute("connected");
            connAttribute.Value = graph.IsConnected.ToString().ToLower();
            rootNode.Attributes.Append(connAttribute);
            xmlDoc.AppendChild(rootNode);
            
            //Name node  
            XmlNode nameNode = xmlDoc.CreateElement("name");
            nameNode.InnerText = graph.Name;
            rootNode.AppendChild(nameNode);

            //Description node       
            XmlNode descriptionNode = xmlDoc.CreateElement("description");
            descriptionNode.InnerText = graph.Description;
            rootNode.AppendChild(descriptionNode);
            return xmlDoc;
        }

        public static string GetXMLAsString(XmlDocument myxml)
        {
            return myxml.OuterXml;
        }

        public static string GetStatistics(this Graph graph)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.Append(String.Format("{0,6} {1,15}\n\n", "Name", graph.Name));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "Description", graph.Description));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "IsConnected", graph.IsConnected));
            string newString = Convert.ToString(myStringBuilder);
            

            return newString;
        }
    }
}
