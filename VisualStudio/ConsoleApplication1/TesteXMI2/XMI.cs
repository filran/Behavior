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
        public const string EXTENSION = "Extension";
            
        public string ArquivoXmi { get; private set; }
        public XmlDocument xmlDocument = new XmlDocument();

        public ArrayList OwnedBehavior { get; private set; }
        public ArrayList Lifeline { get; private set; }
        public ArrayList Fragment { get; private set; }
        public ArrayList Message { get; private set; }

        /* Example of the Digrams
         * 
         * Digrams.Add( EAID_C5A4346A_C4D2_4a24_BDFB_CB31D97D8BDC , new ArrayList(){ new Element("tag", Atributos) , new Element("tag", Atributos) ,...} );
         * 
         */
        public Dictionary<string, ArrayList > Diagrams { get; private set; }
        public ArrayList Element { get; private set; }


        public XMI(string arquivoXmi)
        {
            this.OwnedBehavior = new ArrayList();
            this.Lifeline = new ArrayList();
            this.Fragment = new ArrayList();
            this.Message = new ArrayList();
            this.Diagrams = new Dictionary<string, ArrayList>();
            this.Element = new ArrayList();
              
            this.xmlDocument.Load(arquivoXmi);

            readTag(xmlDocument.SelectNodes("//" + OWNEDBEHAVIOR));
            readTag(xmlDocument.SelectNodes("//" + DIAGRAM));
            readTag(xmlDocument.SelectNodes("//" + ELEMENTS));

            //SHOW DIAGRAMS
            //foreach (var d in Diagrams)
            //{
            //    Console.WriteLine(d.Key);
            //    foreach (Element dd in d.Value)
            //    {
            //        Console.Write(dd.Tag + " ");
            //        foreach (var ddd in dd.AttributesElement)
            //        {
            //            Console.WriteLine(ddd.Key + "=" + ddd.Value);
            //        }
            //    }
            //    Console.WriteLine("\n");
            //}

            //SHOW ELEMENTS
            foreach(Element e in Element)
            {
                Console.Write( e.Tag + " ");

                foreach (var a in e.AttributesElement)
                {
                    //Console.WriteLine( a.Key +"="+ a.Value);
                }
            }

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
                foreach (XmlNode x in node.ChildNodes)
                {
                    Dictionary<string, string> attr = readAttributes(x);
                    createElement(x, attr);

                    //SALVE CHILDS' DIAGRAM ///////////////////////////////////////////////////
                    string id_diagram = "";
                    if (x.ParentNode.Name == DIAGRAM || x.ParentNode.ParentNode.Name == DIAGRAM)
                    {                        
                        if( x.ParentNode.Name == DIAGRAM  )
                        {
                            id_diagram = x.ParentNode.Attributes["xmi:id"].Value;
                        }
                        else if (x.ParentNode.ParentNode.Name == DIAGRAM)
                        {
                            id_diagram = x.ParentNode.ParentNode.Attributes["xmi:id"].Value;
                        }

                        foreach( var d in this.Diagrams )
                        {
                            if (d.Key == id_diagram)
                            {
                                d.Value.Add( new Element(x.Name,attr) );
                            }
                        }
                    }//////////////////////////////////////////////////////////////////////////

                    //SALVE CHILDS'S ELEMENTS /////////////////////////////////////////////////////////
                    if( x.ParentNode.Name == EXTENSION && x.FirstChild.Name == ELEMENT )
                    {
                        Console.WriteLine("goooooooooooooooollllllllllllllllll");


                    }//////////////////////////////////////////////////////////////////////////////////
                    
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
                    //this.Diagram.Add(new Element(tag.Name, attr));
                    this.Diagrams.Add(attr["xmi:id"], new ArrayList() { new Element(tag.Name, attr) });
                    break;
                //case ELEMENT:
                //    this.Element.Add(new Element(tag.Name, attr));
                //    break;
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