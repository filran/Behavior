//INSTRUCTIONS
// The symbol "_" is used for inherit and for separate the class' name the first letter of next word is uppercase

using System;

namespace TesteXML2
{
    public class Diagram
    {
        protected string id;
        protected string name;

        public Diagram()
        {

        }
    }

    //STRUCTURAL AND BEHAVIORAL INHERIT DIAGRAM
    public class Structural_Diagram : Diagram
    {

    }


    //==========================================================================================================================================================================================
    public class Behavioral_Diagram : Diagram
    {

    }

    //THIS CLASS ABOVE INHERIT BEHAVIORAL

        //ACTIVITY DIAGRAM
        public class Ativicty : Behavioral
        {

        }

        //SEQUENCE DIAGRAM
        public class Sequence_Behavioral_Diagram: Behavioral_Diagram
        {

        }

        public class LifeTime
        {
            public string id;
            public string name;
        }

        public class MessageSequence
        {

        }

        public class Synchronous_MessageSequence : MessageSequence
        {

        }

        public class Asynchronous_MessageSequence : MessageSequence
        {

        }

}