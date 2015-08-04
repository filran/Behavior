/*
 * ----------------------------------------------------------------------------------
 *                      DEVELOPMENT BY FILIPE ARANTES                               *
 *                 filran@gmail.com | ffernandes@cos.ufrj                           *
 * ----------------------------------------------------------------------------------
 * 
 * The XMI class it has propose read a file XMI. 
 * The access his content is through by public variables, e.g., OwnedBehavior, Lifeline ...
 */
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace TesteXMI2
//{
    public class Diagram
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public XMI FileXMI { get; set;}
		public ArrayList SequenceDiagrams { get; private set;} //store the objects of class Sequence

        public Diagram( string xmi )
        {
            //string arquivoXmi = "F:\\Documentos\\Programacao\\GitHub\\Behavior\\VisualStudio\\ConsoleApplication1\\TesteXMI2\\DiaSeqs_XMI2.1.xml";
            this.FileXMI = new XMI(xmi);

			//add objects of class Sequence
			this.SequenceDiagrams = new ArrayList ();

            identifyTypeDiagram();
        }

    
		public Diagram() { }


        private void identifyTypeDiagram()
        {   
			foreach(var d in this.FileXMI.Diagrams)
            {
                foreach(Element dd in d.Value)
                {
                    if (dd.Tag == "properties" && dd.AttributesElement["type"] == "Sequence" )
                    {
						this.SequenceDiagrams.Add( new Sequence( d.Value ) );
                    }
                }
            }
        }

    	
		public void setIdandName( ArrayList d ){
			foreach(Element e in d )
			{
				if( e.Tag == "diagram" )
				{
					this.Id = e.AttributesElement["xmi:id"];
				}
				else if ( e.Tag == "properties" )
				{
					this.Name = e.AttributesElement["name"];
				}

			}
		}	

		//Method implemented for all class
		protected static void render (Diagram d){}
	

    }


        public abstract class Behavioral : Diagram
        {
            public Behavioral() {
                
            }
        }

            public class Sequence : Behavioral
            {
				//store sequence of type Element
				public ArrayList ElementsSequence { get; private set; }
				//store the objects or actors
				public Dictionary<string,ArrayList> Objects { get; private set;}
				//store messagens
				public ArrayList Messages { get; private set; }
                
				//CONSTRUCTOR
				public Sequence(ArrayList e)
				{
					this.ElementsSequence = e;
					this.setIdandName ( e );

					this.Objects = new Dictionary<string,ArrayList>();
				}


				public void render( Diagram d )
				{
					
					//store <lifeline> and <element> of "Objetos" in Objects==============================
					foreach( Element l in d.FileXMI.Lifeline ){
						foreach( var dd in d.FileXMI.Diagrams ){
							if( dd.Key == this.Id ){
								foreach(Element e in dd.Value ){
									if(e.Tag=="element" && e.AttributesElement["subject"] == l.AttributesElement["xmi:id"]){
										if( this.Objects.Count > 0 ){
											if( this.Objects.Last().Key != l.AttributesElement["xmi:id"] ){
												this.Objects.Add(l.AttributesElement["xmi:id"],new ArrayList(){e,l});
											}
										}else{
											this.Objects.Add(l.AttributesElement["xmi:id"],new ArrayList(){e,l});
										}																		
									}
								}
							}
						}
					}//=====================================================================================				


					

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
