using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteXMI2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sequence seq1 = new Sequence("01","Diagrama de Sequencia 1");

            Lifeline life1 = new Lifeline("01", "Object1");
            Lifeline life2 = new Lifeline("02", "Object2");
            Lifeline life3 = new Lifeline("03", "Object3");

            Synchronous msg1 = new Synchronous("01","Msg01","01","02");
            Asynchronous msg2 = new Asynchronous("02", "Msg02", "02", "01");

            //ADD LIFELINES
            ArrayList lifelines = new ArrayList();
            lifelines.Add(life1);
            lifelines.Add(life2);
            lifelines.Add(life3);
            seq1.addLifelines(lifelines);

            //ADD MESSAGES
            ArrayList msgSync = new ArrayList();
            msgSync.Add(msg1);
            life1.addSynchronous(msgSync);

            ArrayList msgAsync = new ArrayList();
            msgAsync.Add(msg2);
            life2.addAsynchronous(msgAsync);

        }
    }
}
