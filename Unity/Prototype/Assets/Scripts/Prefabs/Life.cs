using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public GameObject Object; //Is the area of object name or actor
	public TextMesh ObjectName; //Name of object
	public GameObject Lifeline; //Is the line of life in the vertical
	private string objectname;

	// Use this for initialization
	void Start () {
		ObjectName.text = objectname;
	}

	public void setObjectName( string name ){
		this.objectname = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
