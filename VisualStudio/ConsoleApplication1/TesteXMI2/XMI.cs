using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TesteXMI2
{
    public class XMI
    {
        public string ArquivoXmi { get; private set; }
        public XmlDocument xmlDocument = new XmlDocument();

        public ArrayList OwnedBehavior { get; private set; }
        public ArrayList Lifeline { get; private set; }
        public ArrayList Message { get; private set; }

        public XMI(string arquivoXmi)
        {
            this.xmlDocument.Load(arquivoXmi);
            ownedBehavior();
        }

        private void ownedBehavior()
        {
            OwnedBehavior = new ArrayList();
            Lifeline = new ArrayList();
            Message = new ArrayList();

            foreach (XmlNode x in this.xmlDocument.SelectNodes("//ownedBehavior"))
            {
                string type = x.Attributes["xmi:type"].Value;
                string id = x.Attributes["xmi:id"].Value;
                string name = x.Attributes["name"].Value;
                string visibility = x.Attributes["visibility"].Value;

                OwnedBehavior.Add( new Element(type,id,name,visibility) );
                
                foreach (XmlNode n in x.ChildNodes)
                {
                    if (n.Name == "lifeline")
                    {
                        Lifeline.Add(new Element(n.Attributes["xmi:type"].Value, n.Attributes["xmi:id"].Value, n.Attributes["name"].Value, n.Attributes["visibility"].Value, n.Attributes["represents"].Value));
                    }

                    if (n.Name == "message")
                    {
                        Message.Add(new Element(n.Attributes["xmi:type"].Value, n.Attributes["xmi:id"].Value, n.Attributes["name"].Value, n.Attributes["messageKind"].Value, n.Attributes["messageSort"].Value, n.Attributes["sendEvent"].Value, n.Attributes["receiveEvent"].Value));
                    }
                }
            }
        }

    }

    public class Element
    {
        public string Xmi_type { get; private set; }
        public string Xmi_id { get; private set; }
        public string Name { get; private set; }
        public string Visibility { get; private set; }
        public string Represents { get; private set; }
        public string MessageKind { get; private set; }
        public string MessageSort { get; private set; }
        public string SendEvent { get; private set; }
        public string ReceiveEvent { get; private set; }
        
        //Elements childs from parent element
        public ArrayList Childs { get; private set; }

        public Element()
        {

        }

        //<ownedBehavior>
        public Element(string xmi_type, string xmi_id, string name, string visibility)
        {
            this.Xmi_type = xmi_type;
            this.Xmi_id = xmi_id;
            this.Name = name;
            this.Visibility = visibility;
        }

        //<lifeline>
        public Element(string xmi_type, string xmi_id, string name, string visibility, string represents)
        {
            this.Xmi_type = xmi_type;
            this.Xmi_id = xmi_id;
            this.Name = name;
            this.Visibility = visibility;
            this.Represents = represents;
        }

        //<message>
        public Element(string xmi_type, string xmi_id, string name, string messageKind, string messageSort, string sendEvent, string receiveEvent)
        {
            this.Xmi_type = xmi_type;
            this.Xmi_id = xmi_id;
            this.Name = name;
            this.MessageKind = messageKind;
            this.MessageSort = messageSort;
            this.SendEvent = sendEvent;
            this.ReceiveEvent = receiveEvent;
        }
    }

}