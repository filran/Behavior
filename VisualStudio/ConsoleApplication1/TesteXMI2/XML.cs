using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteXMI2
{
    public class XML
    {

        public ArrayList Elements { get; private set; }
        public string Arquivo { get; private set; }

        public XML(string arquivo)
        {
            this.Arquivo = arquivo;
        }

        public void addElements(ArrayList elements){
            this.Elements = elements;
        }

    }

    public class Element
    {

        public ArrayList Attributes { get; private set; }

        public Element()
        {

        }

        public void addAttributes(ArrayList attributes)
        {
            this.Attributes = attributes;
        }
    }

    public class Attribute
    {

    }
}
