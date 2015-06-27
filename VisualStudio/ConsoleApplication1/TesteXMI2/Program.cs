using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TesteXMI2
{
    class Program
    {

        static void Main(string[] args)
        {
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


            //string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\teste.xmi";
            string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeq_XMI2.1.xmi";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(arquivoXmi); //Carregando o arquivo

            //Pegando elemento pelo nome da TAG
            

            //Usando foreach para imprimir na tela
            foreach (XmlNode xn in xnList)
            {
               
            }



        }


        //Funcao Recursiva
        //É capaz de nos retornar a referencia de qualquer nó no arquivo xml
        //sendo descendente do no passado na funcao.
        public static XmlNode BuscaXml(XmlNode node, String NodeName)
        {
            //se é o que estamos procurando, o retorna
            if (node.Name == NodeName)
                return node;
            //caso este no nao possua filhos, retorne null
            if (node.ChildNodes.Count == 0)
                return null;
 
            XmlNode No_temp;
            //para cada filho de um determinado nó.
            foreach (XmlNode no in node.ChildNodes)
            {
                //inicia recursao
                No_temp = BuscaXml(no, NodeName);
         
                //caso nao exista, continua a iteracao
                if (No_temp == null)
                    continue;
                //caso exista, retorne para continuar a busca
                else
                    return No_temp;
            }
            //caso nao encontre...
            return null;
        }

    }
}
