using UnityEngine;
using System.Collections;

public class SceneDiagram : MonoBehaviour {

	private Diagram diagram { get; set; }
	public GameObject Life;
	private const int SPACEX = 2;
	private GameObject ins;
	public ArrayList instances{ get; private set; }


	// Use this for initialization
	void Start () {
//		Debug.Log ( PlayerPrefs.GetString("idDiagramLoaded") );

		//Instance class Diagram
		this.diagram = new Diagram ( PlayerPrefs.GetString("arquivoXMI") );

		//if one sequence diagram clicked....
		if( PlayerPrefs.GetString("typeDiagramLoaded") == "Sequence" )
		{
			//Select the sequence diagram clicked 
			foreach( Sequence s in this.diagram.SequenceDiagrams ){
				
				//confirm the diagram selected and clicked
				if( s.Id == PlayerPrefs.GetString("idDiagramLoaded") ){
					//				Debug.Log( s.Id + " = " + PlayerPrefs.GetString("idDiagramLoaded") );
					
					//THIS SCOPE WILL RENDER THE DIAGRAM !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
					// Render Lifes, Messages with his animations

					s.render( this.diagram );

					if( s.Objects.Count > 0 ){
						//setup for position
						float increment = (this.Life.transform.localScale.x / 2) + SPACEX;
						float position = 0;

						foreach( var o in s.Objects ){
//							Debug.Log( o.Key );
							string nameObject = "";

							foreach(Element oo in o.Value){
								if( oo.Tag=="lifeline" && oo.AttributesElement["xmi:id"]== o.Key  ){
									nameObject = oo.AttributesElement["name"];
								}
							}

							//position
							float posLx = position;
							float posLy = this.Life.transform.position.y;
							float posLz = this.Life.transform.position.z;
							
							//create a vector3
							Vector3 posLife = new Vector3 (posLx, posLy, posLz);
							
							//for each diagram create a instance of buttondiagram
							ins = (GameObject)Instantiate (this.Life, posLife, Quaternion.identity) ;
							
							//here send the name, id and type each diagram for the class ButtonDiagram
							ins.GetComponentInChildren<Life>().setObjectName( nameObject );

//								ins.GetComponentInChildren<ButtonDiagram>().NameDiagram ( s.Name );
//								ins.GetComponentInChildren<ButtonDiagram>().IdDiagram(s.Id);
//								ins.GetComponentInChildren<ButtonDiagram>().TypeDiagram( s.GetType().ToString() );
							
							//create a array with all instances
//								instances.Add(ins);
							
							//change the position of buttons
							position += increment;

						}
					}

				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
