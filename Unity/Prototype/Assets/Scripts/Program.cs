using UnityEngine;
using System.Collections;

public class Program : MonoBehaviour
{

	private Diagram diagram { get; set; }
	public string arquivoXMI;
	public GameObject ButtonDiagramGameObject;
	private const int SPACEX = 2;

	// Use this for initialization
	void Start ()
	{
		this.diagram = new Diagram (arquivoXMI);

		ButtonForEachSequenceDiagram ();
	}


	//BUTTON FOR EACH SEQUENCE DIAGRAM
	private void ButtonForEachSequenceDiagram()
	{
		if (this.diagram.SequenceDiagrams.Count > 0) {
			float increment = (this.ButtonDiagramGameObject.transform.localScale.x / 2) + SPACEX;
			float position = 0;

			foreach( Sequence s in this.diagram.SequenceDiagrams )
			{
				float posBDx = position;
				float posBDy = this.ButtonDiagramGameObject.transform.position.y;
				float posBDz = this.ButtonDiagramGameObject.transform.position.z;

				Vector3 posButtonDiagram = new Vector3 (posBDx, posBDy, posBDz);
				GameObject ins = (GameObject)Instantiate (this.ButtonDiagramGameObject, posButtonDiagram, Quaternion.identity);

				string random = Random.Range (0.0f, 10.0f).ToString ();

				ins.GetComponentInChildren<ButtonDiagram> ().NameDiagram ( s.Name );

				position += increment;
			}
		}
	}
	

	// Update is called once per frame
	void Update ()
	{
	
	}
}

