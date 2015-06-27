using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteXML2
{
    public class Diagram
    {
        //DECLARATE VAR AND GET AND SET
        public string Id {get; private set;}
        public string Name { get; private set; }

        public Diagram(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


    }

    //STRUCTURAL AND BEHAVIORAL INHERIT DIAGRAM
    public class Structural : Diagram
    {
        
    }


    //==========================================================================================================================================================================================
    public class Behavioral : Diagram
    {
        public Behavioral():base(id,name)
        {
            
        }
    }

    //THIS CLASS ABOVE INHERIT BEHAVIORAL

        //ACTIVITY DIAGRAM
        public class Ativicty : Behavioral
        {

        }

        //SEQUENCE DIAGRAM
        public class Sequence: Behavioral_Diagram
        {
            protected Dictionary<string, Lifeline> lifelines;
            protected Dictionary<string, Synchronous> synchronous;
            protected Dictionary<string, Asynchronous> asynchronous;

            public Sequence():base(id,name)
            {
                Console.WriteLine(this.Id);
            }
        }

        public class Lifeline
        {
            public string id;
            public string name;
        }

        public abstract class MessageSequence
        {
            protected string id;
            protected string name;
            protected string sendEvent;
            protected string receiveEvent;

        }

        public class Synchronous : MessageSequence
        {

        }

        public class Asynchronous : MessageSequence
        {

        }

}