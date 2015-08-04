using UnityEngine;
using System.Collections;

public class Program : MonoBehaviour
{

	private Diagram diagram { get; set; }
	public string arquivoXMI;
	public GameObject ButtonDiagramGameObject;
	private const int SPACEX = 2;
	private GameObject ins;
	public ArrayList instances{ get; private set; }

	// Use this for initialization
	void Start ()
	{
		//store path of file xmi
		PlayerPrefs.SetString ("arquivoXMI" , this.arquivoXMI);

		this.diagram = new Diagram (arquivoXMI);

		ButtonForEachSequenceDiagram ();

		//TESTS
//		Debug.Log ( this.diagram.FileXMI.Elements.Count );
//		foreach( var e in this.diagram.FileXMI.Elements ){
//			Debug.Log( e.Key );
//			foreach( Element ee in e.Value ){
//				Debug.Log( ee.Tag );
//			}
//		}

	}


	//BUTTON FOR EACH SEQUENCE DIAGRAM
	private void ButtonForEachSequenceDiagram()
	{
		instances = new ArrayList ();

		if (this.diagram.SequenceDiagrams.Count > 0) {
			//setup for position
			float increment = (this.ButtonDiagramGameObject.transform.localScale.x / 2) + SPACEX;
			float position = 0;

			foreach( Sequence s in this.diagram.SequenceDiagrams )
			{
				//position
				float posBDx = position;
				float posBDy = this.ButtonDiagramGameObject.transform.position.y;
				float posBDz = this.ButtonDiagramGameObject.transform.position.z;

				//create a vector3
				Vector3 posButtonDiagram = new Vector3 (posBDx, posBDy, posBDz);

				//for each diagram create a instance of buttondiagram
				ins = (GameObject)Instantiate (this.ButtonDiagramGameObject, posButtonDiagram, Quaternion.identity) ;

				//here send the name, id and type each diagram for the class ButtonDiagram
				ins.GetComponentInChildren<ButtonDiagram>().NameDiagram ( s.Name );
				ins.GetComponentInChildren<ButtonDiagram>().IdDiagram(s.Id);
				ins.GetComponentInChildren<ButtonDiagram>().TypeDiagram( s.GetType().ToString() );

				//create a array with all instances
				instances.Add(ins);

				//change the position of buttons
				position += increment;
			}
		}
	}
	

	// Update is called once per frame
	void Update ()
	{

	}
	
}

