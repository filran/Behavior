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

//namespace TesteXMI2
//{
    public class Diagram
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        private XMI FileXMI { get; set;}
        private Dictionary<string, ArrayList> Diagrams { get; set; }
        public ArrayList IdSequenceDiagram { get; private set; } //SALVE THE XMI:ID

        public Diagram( string xmi )
        {
            //string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";
            this.FileXMI = new XMI(xmi);
            this.Diagrams = this.FileXMI.Diagrams;
            this.IdSequenceDiagram = new ArrayList();

            identifyTypeDiagram();
        }

        public Diagram() { }

        private void identifyTypeDiagram()
        {   
            foreach(var d in this.Diagrams)
            {
                foreach(Element dd in d.Value)
                {
                    if (dd.Tag == "properties" && dd.AttributesElement["type"] == "Sequence" )
                    {
                        this.IdSequenceDiagram.Add(d.Key);
                    }
                }
            }
        }
    
    }//END DIAGRAM CLASS


        public abstract class Behavioral : Diagram
        {
            public Behavioral() {
                
            }
        }

            public class Sequence : Behavioral
            {

                //RELATIONSHIP
                public ArrayList Lifelines { get; private set; }
                
                //CONSTRUCTOR
                public Sequence() {
                    identifySequenceDiagram();
                }

                private void identifySequenceDiagram()
                {
                    if( IdSequenceDiagram.Count > 0 ){
                        //Console.WriteLine("Temos " + IdSequenceDiagram.Count+" diagramas de sequencia");
                    }
                }


                public void addLifelines (ArrayList lifelines)
                {
                    this.Lifelines = lifelines;
                }

            }

                //public class Lifeline
                //{
                //    public string Id { get; private set; }
                //    public string Name { get; private set; }

                //    //RELATIONSHIP  
                //    public ArrayList Synchronous { get; private set; }
                //    public ArrayList Asynchronous { get; private set;  }

                //    //CONSTRUCT
                //    public Lifeline(string id, string name)
                //    {
                //        this.Id = id;
                //        this.Name = name;
                //    }

                //    public void addSynchronous(ArrayList synchronous)
                //    {
                //        this.Synchronous = synchronous;
                //    }

                //    public void addAsynchronous(ArrayList asynchronous)
                //    {
                //        this.Asynchronous = asynchronous;
                //    }

                //}

                //public abstract class MessageSequence
                //{
                //    public string Id { get; private set; }
                //    public string Name { get; private set; }
                //    public string SendEvent { get; private set; }
                //    public string ReceiveEvent { get; private set; }

                //    public MessageSequence(string id, string name, string sendevent, string receiveevent)
                //    {
                //        this.Id = id;
                //        this.Name = name;
                //        this.SendEvent = sendevent;
                //        this.ReceiveEvent = receiveevent;
                //    }
                //}

                //    public class Synchronous : MessageSequence
                //    {
                //        public Synchronous(string id, string name, string sendevent, string receiveevent) : base(id, name, sendevent, receiveevent) { }
                //    }

                //    public class Asynchronous : MessageSequence
                //    {
                //        public Asynchronous(string id, string name, string sendevent, string receiveevent) : base(id, name, sendevent, receiveevent) { }
                //    }
//}
