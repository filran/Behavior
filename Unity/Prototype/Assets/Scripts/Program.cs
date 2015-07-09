using UnityEngine;
using System.Collections;

public class Program : MonoBehaviour
{

	private Diagram diagram { get; set; }
	public string arquivoXMI;
	public GameObject ButtonDiagram;
	private const int SPACEX = 3;
	private float widthscreen = (float) Screen.width;
	private float heightscreen = (float) Screen.height;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ( widthscreen );

		Diagram diagram = new Diagram (arquivoXMI);

		if( diagram.IdSequenceDiagram.Count > 0 )
		{
			float scaleX = ButtonDiagram.transform.localScale.x;
			float radius = scaleX / 2;
			float sumRadius = diagram.IdSequenceDiagram.Count * radius;
			float FirstPosBDx = ( sumRadius / diagram.IdSequenceDiagram.Count ) * 1;

			for(int i=1 ; i<=diagram.IdSequenceDiagram.Count; i++)
			{
				float posBDx = FirstPosBDx * ( i ) ;
				float posBDy = ButtonDiagram.transform.position.y;
				float posBDz = ButtonDiagram.transform.position.z;

				Vector3 posButtonDiagram = new Vector3( posBDx, posBDy, posBDz );
				Instantiate(ButtonDiagram , posButtonDiagram , Quaternion.identity);

				Debug.Log ( posBDx );
			}

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

