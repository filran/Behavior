using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TesteXMI3
{
    class XMI
    {
        private const string ROOT = "xmi:XMI";

        private XmlDocument xmlDocument = new XmlDocument();
        private string arquivoXmi { get; set; }

        public XMI( string file )
        {
            this.arquivoXmi = file;
            this.xmlDocument.Load(this.arquivoXmi);


        }

        private void readRoot()
        {
            XmlNodeList root = this.xmlDocument.GetElementsByTagName(ROOT);

            foreach( XmlNode node in root )
            {
                if(  ){

                }
            }
        }

        private void loop( XmlNode node )
        {
            foreach( XmlNode n in node )
            {

            }
        }
    }


}
