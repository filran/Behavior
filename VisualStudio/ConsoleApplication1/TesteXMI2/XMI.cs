﻿using System;
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
            //ownedBehavior();
        }



        //METHOD TO READ THE ELEMENT AND HIS ATTRIBUTES
        private Element readElementAttributes(string readtag)
        {
            //CREATE THE ELEMENT OBJ
            Element element = new Element();

            foreach (XmlNode xmlNode in xmlDocument.SelectNodes(readtag))
            {
                //ADD OBJ'S NAME
                element.Tag = xmlNode.Name;

                //CREATE ATTR OBJ
                Dictionary<string, string> attributes = new Dictionary<string, string>();

                //READ THE ATTRIBUTES AND ADD
                foreach (XmlAttribute attr in xmlNode.Attributes)
                {
                    attributes.Add(attr.Name, attr.Value); //Console.Write("{0}={1} ", attr.Name, attr.Value);
                }

                //ADD OBJ'S ATTR
                element.AttributesElement = attributes;
            }
            return element;
        }

        
        private void ownedBehavior()
        {
            OwnedBehavior = new ArrayList();
            Lifeline = new ArrayList();
            Message = new ArrayList();      
        }

    }

    public class Element
    {
        public string Tag { get; set; } //<Tag>
        public Dictionary<string, string> AttributesElement { get; set; } //<Tag att1="value1" att2="value2" ... />

        public Element(){}
    }

    //public class Element
    //{
    //    public string Xmi_type { get; private set; }
    //    public string Xmi_id { get; private set; }
    //    public string Name { get; private set; }
    //    public string Visibility { get; private set; }
    //    public string Represents { get; private set; }
    //    public string MessageKind { get; private set; }
    //    public string MessageSort { get; private set; }
    //    public string SendEvent { get; private set; }
    //    public string ReceiveEvent { get; private set; }
        
    //    //Elements childs from parent element
    //    public ArrayList Childs { get; private set; }

    //    public Element()
    //    {

    //    }

    //    //<ownedBehavior>
    //    public Element(string xmi_type, string xmi_id, string name, string visibility)
    //    {
    //        this.Xmi_type = xmi_type;
    //        this.Xmi_id = xmi_id;
    //        this.Name = name;
    //        this.Visibility = visibility;
    //    }

    //    //<lifeline>
    //    public Element(string xmi_type, string xmi_id, string name, string visibility, string represents)
    //    {
    //        this.Xmi_type = xmi_type;
    //        this.Xmi_id = xmi_id;
    //        this.Name = name;
    //        this.Visibility = visibility;
    //        this.Represents = represents;
    //    }

    //    //<message>
    //    public Element(string xmi_type, string xmi_id, string name, string messageKind, string messageSort, string sendEvent, string receiveEvent)
    //    {
    //        this.Xmi_type = xmi_type;
    //        this.Xmi_id = xmi_id;
    //        this.Name = name;
    //        this.MessageKind = messageKind;
    //        this.MessageSort = messageSort;
    //        this.SendEvent = sendEvent;
    //        this.ReceiveEvent = receiveEvent;
    //    }
    //}

}