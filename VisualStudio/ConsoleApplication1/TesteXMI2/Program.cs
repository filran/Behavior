// >>>> LER OS ATRIBUTOS E VALORES AUTOMATICAMENTE


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
            //string arquivoXmi = "F:\\Users\\Filipe\\Documents\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeq_XMI2.1.xmi";
            string arquivoXmi = "F:\\Users\\Filipe\\Documents\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";

            XMI xmi = new XMI(arquivoXmi);



            ////Declarando uma nova instancia XmlDocument
            //XmlDocument xmlDocument = new XmlDocument();
            //string arquivoXmi = @"F:\Users\Filipe\Documents\Programacao\GitHub\Behavior\VisualStudio\ConsoleApplication1\TesteXMI2\DiaSeq_XMI2.1.xmi";
            ////Carregando XML do disco rigido
            //xmlDocument.Load(arquivoXmi);

            ////foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("ownedBehavior"))
            ////{
            ////    Console.WriteLine("ownedBehavior: {0}", xmlNode.Attributes["xmi:id"].Value);
            ////}

            //foreach (XmlNode xmlNode in xmlDocument.SelectNodes("//ownedBehavior"))
            //{
            //    Console.Write("Tipo: {0}\t Nome: {1}\t Atributo: ", xmlNode.NodeType, xmlNode.Name);
            //    Console.WriteLine();

            //    foreach (XmlAttribute attr in xmlNode.Attributes)
            //    {
            //        Console.Write("{0}={1} ", attr.Name, attr.Value);
            //    }                
            //}
            //Console.WriteLine();
            //XMI xmi = new XMI(arquivoXmi);

            //foreach( Element o in xmi.OwnedBehavior ){
            //    Console.WriteLine( ""+o.Name );
                
            //    foreach (Element l in xmi.Lifeline){
            //        Console.WriteLine( "\t"+l.Name );
            //    }

            //    foreach (Element m in xmi.Message)
            //    {
            //        Console.WriteLine( "\t"+m.Name );
            //    }
            //}

            ////Declarando uma nova instancia XmlDocument
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load(arquivoXmi);

            //foreach (XmlNode x in xmlDocument.SelectNodes("//ownedBehavior"))
            //{
            //    Console.WriteLine("ownedBehavior: {0}", x.Attributes["xmi:id"].Value);

            //    foreach (XmlNode nodes in x.ChildNodes )
            //    {
            //        if (nodes.Name == "lifeline")
            //        {
            //            Console.WriteLine( "\tLifeline: " + nodes.Attributes["xmi:id"].Value );
            //        }
            //    }
            //}
            //Sequence seq1 = new Sequence("01","Diagrama de Sequencia 1");

            //Lifeline life1 = new Lifeline("01", "Object1");
            //Lifeline life2 = new Lifeline("02", "Object2");
            //Lifeline life3 = new Lifeline("03", "Object3");

            //Synchronous msg1 = new Synchronous("01","Msg01","01","02");
            //Asynchronous msg2 = new Asynchronous("02", "Msg02", "02", "01");

            ////ADD LIFELINES
            //ArrayList lifelines = new ArrayList();
            //lifelines.Add(life1);
            //lifelines.Add(life2);
            //lifelines.Add(life3);
            //seq1.addLifelines(lifelines);

            ////ADD MESSAGES
            //ArrayList msgSync = new ArrayList();
            //msgSync.Add(msg1);
            //life1.addSynchronous(msgSync);

            //ArrayList msgAsync = new ArrayList();
            //msgAsync.Add(msg2);
            //life2.addAsynchronous(msgAsync);          

        }
    }
}
