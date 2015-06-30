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
        //TAGS IN XMI
        public const string OWNEDBEHAVIOR = "ownedBehavior";
        public const string LIFELINE = "lifeline";
        public const string MESSAGE = "message";
        public const string DIAGRAM = "diagram";
        public const string ELEMENTS = "elements";
        public const string ELEMENT = "element";
            
        public string ArquivoXmi { get; private set; }
        public XmlDocument xmlDocument = new XmlDocument();

        public ArrayList OwnedBehavior { get; private set; }
        public ArrayList Lifeline { get; private set; }
        public ArrayList Message { get; private set; }

                        //Diagram   Element
        public Dictionary<ArrayList,ArrayList> Diagrams { get; private set; }
        public ArrayList Diagram { get; private set; }
        //public ArrayList Element { get; private set; }

        public XMI(string arquivoXmi)
        {
            this.OwnedBehavior = new ArrayList();
            this.Lifeline = new ArrayList();
            this.Message = new ArrayList();

            this.Diagrams = new Dictionary<ArrayList, ArrayList>();
            this.Diagram = new ArrayList();
            //this.Element = new ArrayList();
              
            this.xmlDocument.Load(arquivoXmi);

            readElement("/" + OWNEDBEHAVIOR);
            readElement("/" + OWNEDBEHAVIOR + "/" + LIFELINE);
            readElement("/" + OWNEDBEHAVIOR + "/" + MESSAGE);
            
            readElement("/" + DIAGRAM);
            //readElement("/" + DIAGRAM + "/" + ELEMENTS + "/" + ELEMENT);
        }


        //READ THE ELEMENTS AND ADD IN YOUR ARRAYLIST
        private void readElement(string tag)
        {
            ArrayList tagList = splitTags(tag);
            int count = tagList.Count;
            int lastIndex = count - 1;
            string lastPosition = tagList[lastIndex].ToString();

            ArrayList element = new ArrayList();

            switch (lastPosition)
            {
                case OWNEDBEHAVIOR:     foreach (Element e in readElementAttributes(tag)) { this.OwnedBehavior.Add(e); } break;
                case LIFELINE:          foreach (Element e in readElementAttributes(tag)) { this.Lifeline.Add(e); } break;
                case MESSAGE:           foreach (Element e in readElementAttributes(tag)) { this.Message.Add(e); } break;
                //case DIAGRAM:           foreach (Element e in readElementAttributes(tag)) { this.Diagram.Add(e); } break;
                case ELEMENT:           foreach (Element e in readElementAttributes(tag)) { element.Add(e); } break;

                case DIAGRAM:
                    foreach (Element e in readElementAttributes(tag))
                    {
                        this.Diagram.Add(e);

                    }
                    break;
            }

        }


        //METHOD TO READ THE ELEMENT AND HIS ATTRIBUTES
        private ArrayList readElementAttributes(string readtag)
        {
            //REPLACE FROM / TO //
            readtag = replaceBar(readtag);

            //CREATE ARRAYLIST WITH ELEMENTS
            ArrayList elementList = new ArrayList();

            foreach (XmlNode xmlNode in xmlDocument.SelectNodes(readtag))
            {
                //CREATE THE ELEMENT OBJ
                Element element = new Element();

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

                elementList.Add(element);
            }
            return elementList;
        }

        //BREAK THE PATH OF TAG
        private ArrayList splitTags(string tag)
        {
            ArrayList list = new ArrayList();
            
            string[] split = tag.Split(new Char[] { '/' });
            foreach (string s in split)
            {
                list.Add(s);
            }

            list.RemoveAt(0);

            return list;
        }

        //REPLACE FROM / TO //
        private string replaceBar(string tags)
        {
            return tags.Replace("/", "//");
        }
    
    }//END CLASS XMI

    public class Element
    {
        public string Tag { get; set; } //<Tag>
        public Dictionary<string, string> AttributesElement { get; set; } //<Tag att1="value1" att2="value2" ... />

        public Element(){}
    
    }//END CLASS ELEMENT

}