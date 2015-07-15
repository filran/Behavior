using UnityEngine;
using System.Collections;

public class ButtonDiagram : MonoBehaviour {

	public TextMesh Name;
	public GameObject Cube;
	private string nameDiagram;
	private float random;

	// Use this for initialization
	void Start () {
//		random = Random.Range(-10.0f, 10.0f);
//		NameDiagram = random.ToString();
		Name.text = nameDiagram;
	}


	public void NameDiagram( string nome ){
		this.nameDiagram = nome;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
