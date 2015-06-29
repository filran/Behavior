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
            string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";

            XMI xmi = new XMI(arquivoXmi);

            ArrayList ownedList = xmi.OwnedBehavior;
            ArrayList lifeList = xmi.Lifeline;
            ArrayList msgList = xmi.Message;

            ArrayList o = xmi.OwnedBehavior;
            foreach (Element oo in o)
            {
                Console.Write("<"+oo.Tag);
                foreach( var a in oo.AttributesElement )
                {
                    Console.Write(" "+a.Key+"="+a.Value+" ");
                }
                Console.WriteLine("/>"); 
            }
               
            ArrayList l = xmi.Lifeline;
            foreach (Element ll in l)
            {
                Console.Write("\t<" + ll.Tag);
                foreach (var a in ll.AttributesElement)
                {
                    Console.Write(" " + a.Key + "=" + a.Value + " ");
                }
                Console.WriteLine("/>");
            }


            ArrayList m = xmi.Message;
            foreach (Element mm in m)
            {
                Console.Write("\t<" + mm.Tag);
                foreach (var a in mm.AttributesElement)
                {
                    Console.Write(" " + a.Key + "=" + a.Value + " ");
                }
                Console.WriteLine("/>");
            }
    

        }
    }
}
