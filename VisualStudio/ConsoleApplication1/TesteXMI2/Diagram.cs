using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteXMI2
{
    public abstract class Diagram
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Diagram(string id, string name)
        {            
            this.Id = id;
            this.Name = name;
            
            Console.WriteLine("Criado o Diagrama: " + this.Id+" - "+this.Name);
        }
    }

        public abstract class Behavioral : Diagram
        {
            public Behavioral(string id, string name) : base(id, name) { }
        }

            public class Sequence : Behavioral
            {

                //RELATIONSHIP
                public ArrayList Lifelines { get; private set; }
                
                //CONSTRUCTOR
                public Sequence(string id, string name) : base(id, name) { }

                public void addLifelines (ArrayList lifelines)
                {
                    this.Lifelines = lifelines;
                }

            }

                public class Lifeline
                {
                    public string Id { get; private set; }
                    public string Name { get; private set; }

                    //RELATIONSHIP  
                    public ArrayList Synchronous { get; private set; }
                    public ArrayList Asynchronous { get; private set;  }

                    //CONSTRUCT
                    public Lifeline(string id, string name)
                    {
                        this.Id = id;
                        this.Name = name;
                    }

                    public void addSynchronous(ArrayList synchronous)
                    {
                        this.Synchronous = synchronous;
                    }

                    public void addAsynchronous(ArrayList asynchronous)
                    {
                        this.Asynchronous = asynchronous;
                    }

                }

                public abstract class MessageSequence
                {
                    public string Id { get; private set; }
                    public string Name { get; private set; }
                    public string SendEvent { get; private set; }
                    public string ReceiveEvent { get; private set; }

                    public MessageSequence(string id, string name, string sendevent, string receiveevent)
                    {
                        this.Id = id;
                        this.Name = name;
                        this.SendEvent = sendevent;
                        this.ReceiveEvent = receiveevent;
                    }
                }

                    public class Synchronous : MessageSequence
                    {
                        public Synchronous(string id, string name, string sendevent, string receiveevent) : base(id, name, sendevent, receiveevent) { }
                    }

                    public class Asynchronous : MessageSequence
                    {
                        public Asynchronous(string id, string name, string sendevent, string receiveevent) : base(id, name, sendevent, receiveevent) { }
                    }
}
