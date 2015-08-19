/*
 * ----------------------------------------------------------------------------------
 *                      DEVELOPMENT BY FILIPE ARANTES                               *
 *                 filran@gmail.com | ffernandes@cos.ufrj                           *
 * ----------------------------------------------------------------------------------
 * 
 * The XMI class it has propose read a file XMI. 
 * The access his content is through by public variables, e.g., OwnedBehavior, Lifeline ...
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

//namespace TesteXMI2
//{
    public class XMI
    {
        //TAGS IN XMI
        private const string OWNEDBEHAVIOR = "ownedBehavior";
        private const string LIFELINE = "lifeline";
        private const string FRAGMENT = "fragment";
        private const string MESSAGE = "message";
        private const string DIAGRAMS = "diagrams";
        private const string DIAGRAM = "diagram";
        private const string ELEMENTS = "elements";
        private const string ELEMENT = "element";
        private const string EXTENSION = "Extension";
            
        private string ArquivoXmi { get; set; }
        private XmlDocument xmlDocument = new XmlDocument();

        public ArrayList OwnedBehavior { get; private set; }
        public ArrayList Lifeline { get; private set; }
        public ArrayList Fragment { get; private set; }
        public ArrayList Message { get; private set; }
		public Dictionary<string, ArrayList > Diagrams { get; private set; }
		/* Example of the Digrams
         * 
         * Digrams.Add( EAID_C5A4346A_C4D2_4a24_BDFB_CB31D97D8BDC , new ArrayList(){ new Element("tag", Atributos) , new Element("tag", Atributos) ,...} );
         * 
         */
		public Dictionary<string, ArrayList > Elements { get; private set; }
		/* Example of the Digrams
         * 
         * Digrams.Add( EAID_C5A4346A_C4D2_4a24_BDFB_CB31D97D8BDC , new ArrayList(){ new Element("tag", Atributos) , new Element("tag", Atributos) ,...} );
         * 
         */

		public Dictionary<string,string> testeAttr { get; set;}
	

        public XMI(string arquivoXmi)
        {
            this.OwnedBehavior = new ArrayList();
            this.Lifeline = new ArrayList();
            this.Fragment = new ArrayList();
            this.Message = new ArrayList();
            this.Diagrams = new Dictionary<string, ArrayList>();
            this.Elements = new Dictionary<string, ArrayList>();
//			this.Elements = new ArrayList ();

			this.testeAttr = new Dictionary<string,string> ();
              
            this.xmlDocument.Load(arquivoXmi);

            readTag(xmlDocument.SelectNodes("//" + OWNEDBEHAVIOR));
            readTag(xmlDocument.SelectNodes("//" + DIAGRAM));
            readTag(xmlDocument.SelectNodes("//" + ELEMENT));

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
					saveChild(x,attr);
                    loopChild(x);
                }
            }
        }

		private void saveChild(XmlNode x , Dictionary<string,string> attr){
		//SALVE CHILDS' DIAGRAM ///////////////////////////////////////////////////
			string id = "";
			if (x.ParentNode.Name == DIAGRAM || x.ParentNode.ParentNode.Name == DIAGRAM)
			{                        
				if( x.ParentNode.Name == DIAGRAM  )
				{
					id = x.ParentNode.Attributes["xmi:id"].Value;
				}
				else if (x.ParentNode.ParentNode.Name == DIAGRAM)
				{
					id = x.ParentNode.ParentNode.Attributes["xmi:id"].Value;
				}

				foreach( var d in this.Diagrams )
				{
					if (d.Key == id)
					{
						d.Value.Add( new Element(x.Name,attr) );
					}
				}
			}//////////////////////////////////////////////////////////////////////////		


			if (x.ParentNode.Name == ELEMENT || x.ParentNode.ParentNode.Name == ELEMENT)
			{                        
				if( x.ParentNode.Name == ELEMENT  )
				{
					id = x.ParentNode.Attributes["xmi:idref"].Value;
				}
				else if (x.ParentNode.ParentNode.Name == ELEMENT)
				{
					id = x.ParentNode.ParentNode.Attributes["xmi:idref"].Value;
				}
				
				foreach( var d in this.Elements )
				{
					if (d.Key == id)
					{
						d.Value.Add( new Element(x.Name,attr) );
					}
				}
			}//////////////////////////////////////////////////////////////////////////		

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
			Random rand = new Random ();

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
                case ELEMENT:					
					foreach( var a in attr ){
						if( a.Key == "xmi:idref" ){
							this.Elements.Add(attr["xmi:idref"], new ArrayList() { new Element(tag.Name, attr) });
						}
					}
                    break;
            }
        }


		//ORDERING THE ELEMENTS OF DIAGRAM IN THE SEQUENCE
		private void orderingElements()
		{
			Dictionary<string,string> toorder = new Dictionary<string,string> ();
			ArrayList oldElements = new ArrayList ();
			
			foreach( var d in this.Diagrams )
			{
				foreach( Element e in d.Value )
				{
					if( e.Tag == "element" )
					{
						toorder.Add( e.AttributesElement["subject"] , e.AttributesElement["seqno"] );
						oldElements.Add(e);
					}
				}
			}

			// Order by values.
			// ... Use LINQ to specify sorting by value.
			var doneorder = from pair in toorder orderby pair.Value descending select pair;

			
			
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

//}