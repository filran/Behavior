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
        public const string FRAGMENT = "fragment";
        public const string MESSAGE = "message";
        public const string DIAGRAMS = "diagrams";
        public const string DIAGRAM = "diagram";
        public const string ELEMENTS = "elements";
        public const string ELEMENT = "element";
            
        public string ArquivoXmi { get; private set; }
        public XmlDocument xmlDocument = new XmlDocument();

        public ArrayList OwnedBehavior { get; private set; }
        public ArrayList Lifeline { get; private set; }
        public ArrayList Fragment { get; private set; }
        public ArrayList Message { get; private set; }

                        //<Diagram> <Element>
        //public Dictionary<Element, ArrayList> Diagrams { get; private set; }
        public Object[,] Diagrams { get; private set; }
        public ArrayList Diagram { get; private set; }
        //public ArrayList Element { get; private set; }


        public XMI(string arquivoXmi)
        {
            this.OwnedBehavior = new ArrayList();
            this.Lifeline = new ArrayList();
            this.Fragment = new ArrayList();
            this.Message = new ArrayList();

            //this.Diagrams = new Dictionary<Element, ArrayList>();
            this.Diagram = new ArrayList();
            //this.Element = new ArrayList();
              
            this.xmlDocument.Load(arquivoXmi);

            readTag(xmlDocument.SelectNodes("//" + OWNEDBEHAVIOR));
            readTag(xmlDocument.SelectNodes("//" + DIAGRAMS));

            foreach (Element e in Diagram)
            {
                Console.WriteLine(e.Tag);
            }


            //TESTE
            //foreach( Element o in OwnedBehavior )
            //{
            //    Console.Write( "<" + o.Tag + " " );
                
            //    foreach( var oo in o.AttributesElement )
            //    {
            //        Console.Write( oo.Key +"="+ oo.Value +" ");
            //    }
            //    Console.WriteLine(" />");
            //}

            //foreach (Element l in Lifeline)
            //{
            //    Console.Write("\t<" + l.Tag + " ");

            //    foreach (var ll in l.AttributesElement)
            //    {
            //        Console.Write(ll.Key + "=" + ll.Value + " ");
            //    }
            //    Console.WriteLine(" />");
            //}

            //foreach (Element e in Fragment)
            //{
            //    Console.Write("\t<" + e.Tag + " ");

            //    foreach (var ee in e.AttributesElement)
            //    {
            //        Console.Write(ee.Key + "=" + ee.Value + " ");
            //    }
            //    Console.WriteLine(" />");
            //}

            //foreach (Element e in Message)
            //{
            //    Console.Write("\t<" + e.Tag + " ");

            //    foreach (var ee in e.AttributesElement)
            //    {
            //        Console.Write(ee.Key + "=" + ee.Value + " ");
            //    }
            //    Console.WriteLine(" />");
            //}

            //foreach (Element e in Diagram)
            //{
            //    Console.Write("<" + e.Tag + " ");

            //    foreach (var ee in e.AttributesElement)
            //    {
            //        Console.Write(ee.Key + "=" + ee.Value + " ");
            //    }
            //    Console.WriteLine(" />");
            //}


        }
        
        //READ THE FIRST NODE
        private void readTag( XmlNodeList nodeList )
        {
            foreach (XmlNode node in nodeList)
            {
                //Console.WriteLine("Parant:" + node.ParentNode.ParentNode.ParentNode.Name );
                Dictionary<string,string>  attr = readAttributes( node );
                createElement( node , attr );
                loopChild(node);
            }
        }

        //READ THE CHILD NODES
        private void loopChild(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                ArrayList elementsDiagram = new ArrayList();
                string idParentDiagram = "";

                foreach (XmlNode x in node.ChildNodes)
                {
                    Dictionary<string, string> attr = readAttributes(x);
                    createElement(x, attr);

                    //IDENTIFY THE ELEMENTS AND ADD IN VAR
                    switch( x.Name )
                    {
                        case ELEMENT:
                            idParentDiagram = x.ParentNode.ParentNode.Attributes["xmi:id"].Value;
                            elementsDiagram.Add( new Element(x.Name,attr) );
                            break;
                    }

                    int countDiagram = this.Diagram.Count;
                    Object[,] Diagrams = new Object[countDiagram, 3];

                    foreach (Element e in this.Diagram)
                    {
                        if (e.AttributesElement["xmi:id"] == idParentDiagram)
                        {
                            //this.Diagrams[0,0] = ""; 
                        }
                    }

                    loopChild(x);
                }
            }
        }

        //READ ATTRIBUTES
        private Dictionary<string,string> readAttributes( XmlNode node )
        {
            Dictionary<string,string> at = new Dictionary<string,string>();

            foreach (XmlAttribute attr in node.Attributes)
            {
                //resp+= " " + attr.Name + "=" + attr.Value + " ";
                at.Add( attr.Name , attr.Value );
            }
            return at;
        }

        //CREATE OBJ ELEMENT AND ADD YOUR ARRAYLIST OR DICTIONARY
        private void createElement( XmlNode tag , Dictionary<string,string> attr)
        {
            switch( tag.Name )
            {
                case OWNEDBEHAVIOR:
                    this.OwnedBehavior.Add(new Element(tag.Name,attr));
                    break;
                case LIFELINE:
                    this.Lifeline.Add(new Element(tag.Name,attr));
                    break;
                case FRAGMENT:
                    this.Fragment.Add(new Element(tag.Name,attr));
                    break;
                case MESSAGE:
                    this.Message.Add(new Element(tag.Name,attr));
                    break;
                case DIAGRAM:
                    this.Diagram.Add(new Element(tag.Name, attr));
                    break;
            }
        }

    
    }//END CLASS XMI

    public class Element
    {
        public string Tag { get; private set; } //<Tag>
        public Dictionary<string, string> AttributesElement { get; private set; } //<Tag att1="value1" att2="value2" ... />

        public Element( string tag , Dictionary<string, string> attr ){
            this.Tag = tag;
            this.AttributesElement = attr;
        }
    
    }//END CLASS ELEMENT

}