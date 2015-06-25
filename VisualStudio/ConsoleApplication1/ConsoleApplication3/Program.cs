//http://blogs.msdn.com/b/yojoshi/archive/2011/05/14/xml-serialization-and-deserialization-entity-classes-with-xsd-exe.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApplication3
{
    class Program
    {
        private static string url;

        static void Main(string[] args)
        {

            url = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\ConsoleApplication3\\Students.xml";

            using (FileStream xmlStream = new FileStream(url, FileMode.Open))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Students));
                    Students deserializedStudents = serializer.Deserialize(xmlReader) as Students;

                    foreach (var student in deserializedStudents.Student)
                    {
                        Console.WriteLine("Roll No : {0}", student.RollNo);
                        Console.WriteLine("Name : {0}", student.Name);
                        Console.WriteLine("Address : {0}", student.Address);
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
