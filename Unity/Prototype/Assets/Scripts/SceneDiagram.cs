using UnityEngine;
using System.Collections;

public class SceneDiagram : MonoBehaviour {

	private Diagram diagram { get; set; }


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

					if( s.Objects != null ){ 
						Debug.Log( s.Objects.Count );

						foreach( var o in s.Objects ){
							Debug.Log( o.Key );
						}
					}

					Debug.Log( this.diagram.FileXMI.Lifeline.Count );
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
