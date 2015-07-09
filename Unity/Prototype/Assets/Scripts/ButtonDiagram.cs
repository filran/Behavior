using UnityEngine;
using System.Collections;

public class ButtonDiagram : MonoBehaviour {

	public TextMesh Name;
	public GameObject Cube;
	public string nameDiagram;

	// Use this for initialization
	void Start () {
		nameDiagram = "arantes";
		Name.text = nameDiagram;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
