﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace TesteXMI1
{
    class Program
    {
        private static string url;

        static void Main(string[] args)
        {
            Console.WriteLine("Teste");

            //TROCAR URL QUANDO ESTIVER EM PC DIFERENTE
            url = "F:\\Users\\Filipe\\Documents\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI1\\DiagramaDeSequencia_1.xml";

            using (FileStream xmlStream = new FileStream(url, FileMode.Open))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XMI));
                    XMI deserializedXMI = serializer.Deserialize(xmlReader) as XMI;

                    foreach (var xmi in deserializedXMI.XMIcontent)
                    {
                        

                    //    Console.WriteLine("Roll No : {0}", student.RollNo);
                    //    Console.WriteLine("Name : {0}", student.Name.Value);
                    //    Console.WriteLine("Gender : {0}", student.Name.gender);
                    //    Console.WriteLine("Address : {0}", student.Address);
                    //    Console.WriteLine("");
                    }
                }
            }
        }
    }
}
