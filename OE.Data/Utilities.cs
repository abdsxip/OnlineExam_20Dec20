using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace OE.Data
{
    public static class Utilities
    {
        /// <summary>
        /// Serializes the object while omitting xml declarations
        /// </summary>
        /// <param name="Pobj">object</param>
        /// <returns>string</returns>
        public static string Serialize(object Pobj)
        {
            MemoryStream LobjMemStm = new MemoryStream();
            XmlWriterSettings LobjXMLSetting = new XmlWriterSettings();
            LobjXMLSetting.OmitXmlDeclaration = true;
            XmlWriter LobjXMLWrite = XmlWriter.Create(LobjMemStm, LobjXMLSetting);
            XmlSerializer PobjXMLSer = new XmlSerializer(Pobj.GetType());
            XmlSerializerNamespaces LobjXSN = new XmlSerializerNamespaces();
            LobjXSN.Add(String.Empty, String.Empty);
            PobjXMLSer.Serialize(LobjXMLWrite, Pobj, LobjXSN);
            LobjXMLWrite.Close();
            LobjMemStm.Close();
            string LobjXML = Encoding.UTF8.GetString(LobjMemStm.GetBuffer());
            LobjXML = LobjXML.Substring(LobjXML.IndexOf(Convert.ToChar(60)));
            LobjXML = LobjXML.Substring(0, (LobjXML.LastIndexOf(Convert.ToChar(62)) + 1));
            return LobjXML;
        }
    }
}
