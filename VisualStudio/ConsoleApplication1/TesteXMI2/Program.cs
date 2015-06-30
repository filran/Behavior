using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TesteXMI2
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<ArrayList, ArrayList> diagrams = new Dictionary<ArrayList, ArrayList>();
            
            string arquivoXmi = "F:\\Users\\Filipe\\Documents\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";
            //string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(arquivoXmi);

            XmlNodeList d = xmlDocument.SelectNodes("//diagrams");

            //diagrams
            foreach( XmlNode c in d ){
                Console.WriteLine( c.Name );
                Console.WriteLine(c.ChildNodes.Count);

                //diagram
                foreach( XmlNode cc in c.ChildNodes ){
                    Console.WriteLine( "\t"+cc.Name );

                    //tags
                    foreach (XmlNode ccc in cc.ChildNodes)
                    {
                        Console.WriteLine("\t\t"+ccc.Name);

                        if( ccc.Name == "elements" )
                        {
                            foreach( XmlNode e in ccc.ChildNodes )
                            {
                                Console.WriteLine("\t\t\t" + e.Name);
                            }
                        }
                    }
                }
            }


            //foreach (XmlNode i in root.ChildNodes)
            //{
            //    //Console.WriteLine(i.Name);
            //}


            //XMI xmi = new XMI(arquivoXmi);

            //ArrayList o = xmi.OwnedBehavior;
            //foreach (Element oo in o)
            //{
            //    Console.Write("<"+oo.Tag);
            //    foreach( var a in oo.AttributesElement )
            //    {
            //        Console.Write(" "+a.Key+"="+a.Value+" ");
            //    }
            //    Console.WriteLine("/>"); 
            //}
               
            //ArrayList l = xmi.Lifeline;
            //foreach (Element ll in l)
            //{
            //    Console.Write("\t<" + ll.Tag);
            //    foreach (var a in ll.AttributesElement)
            //    {
            //        Console.Write(" " + a.Key + "=" + a.Value + " ");
            //    }
            //    Console.WriteLine("/>");
            //}


            //ArrayList m = xmi.Message;
            //foreach (Element mm in m)
            //{
            //    Console.Write("\t<" + mm.Tag);
            //    foreach (var a in mm.AttributesElement)
            //    {
            //        Console.Write(" " + a.Key + "=" + a.Value + " ");
            //    }
            //    Console.WriteLine("/>");
            //}


            //ArrayList d = xmi.Diagram;
            //foreach (Element dd in d)
            //{
            //    Console.Write("\t<" + dd.Tag);
            //    foreach (var a in dd.AttributesElement)
            //    {
            //        Console.Write(" " + a.Key + "=" + a.Value + " ");
            //    }
            //    Console.WriteLine("/>");
            //}

            //ArrayList e = xmi.Element;
            //foreach (Element ee in e)
            //{
            //    Console.Write("\t<" + ee.Tag);
            //    foreach (var a in ee.AttributesElement)
            //    {
            //        Console.Write(" " + a.Key + "=" + a.Value + " ");
            //    }
            //    Console.WriteLine("/>");
            //}


            //ArrayList nomes = new ArrayList();
            //ArrayList idades = new ArrayList();

            //nomes.Add("filipe");
            //nomes.Add("jane");
            //nomes.Add("dayane");

            //idades.Add("29");
            //idades.Add("54");
            //idades.Add("25");

            //Dictionary<ArrayList, ArrayList> dic = new Dictionary<ArrayList, ArrayList>();
            //dic.Add(nomes,idades);

            //foreach( var a in dic)
            //{
            //    foreach( var aa in a.Key )
            //    {
            //        Console.WriteLine( aa );
            //    }
            //    foreach (var aa in a.Value)
            //    {
            //        Console.WriteLine(aa);
            //    }
            //}

        }
    }
}
