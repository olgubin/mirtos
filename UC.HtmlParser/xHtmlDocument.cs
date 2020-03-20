using System;
using System.Collections;
using System.Xml;

namespace UC.DAL.ParsingClient.HtmlToXml
{
	public class XhtmlDocument : XmlDocument
		{
			private readonly Hashtable byHtmlId = new Hashtable();

			public XhtmlDocument(XmlNameTable nt) : base(nt)
			{
			}

			public override void Load(XmlReader reader)
			{
				XmlNodeChangedEventHandler insertHandler = 
					new XmlNodeChangedEventHandler(XhtmlDocument_NodeInserted);

				byHtmlId.Clear();
				NodeInserted += insertHandler;
				try
				{
					base.Load(reader);
				}
				finally
				{
					NodeInserted -= insertHandler;
				}
			}

			public override XmlElement GetElementById(string htmlId)
			{
				return (XmlElement)byHtmlId[htmlId];
			}

			private void XhtmlDocument_NodeInserted(object sender, XmlNodeChangedEventArgs e)
			{
				if (e.Node.NodeType != XmlNodeType.Element) return;

			    XmlAttribute id = e.Node.Attributes["id"];
				if (id != null)
				{
					byHtmlId[id.Value] = e.Node;
				}
			}
		}
}
