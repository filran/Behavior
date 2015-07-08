using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*
 * ArrayList root = ArrayList();
 * 
 * root.Add( new Element("xmi:Documentation",Attributes,text) );
 * root.Add( new Element("uml:Model",Attributes,text) );
 * root.Add( new Element("xmi:Extension",Attributes,text) );
 */

namespace TesteXMI3
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI3\\DiaSeqs_XMI2.1.xml");

            XmlNodeList root = xmlDocument.GetElementsByTagName("xmi:XMI");

            foreach(XmlNode r in root)
            {
                Console.WriteLine( r.Attributes["xmi:version"].Value);
                int childs = r.ChildNodes.Count;

                if( childs > 0 )
                {
                    Console.WriteLine("Possui "+childs+" filhos");

                    foreach( XmlNode c in r )
                    {
                        Console.Write( c.Name );
                        int childss = c.ChildNodes.Count;

                        if( childss > 0 ){
                            Console.WriteLine( " possui " + childss + " filhos" );
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }


        }
    }
}
