using UnityEngine;
using System.Collections;

public class ButtonDiagram : MonoBehaviour {

	public TextMesh Name;
	public GameObject MyCube;
	private string nameDiagram;
	private string idDiagram;
	private float random;
	private string typeDiagram;

	// Use this for initialization
	void Start () {
//		random = Random.Range(-10.0f, 10.0f);
//		NameDiagram = random.ToString();
		Name.text = nameDiagram;

	}


	public void NameDiagram( string nome ){
		this.nameDiagram = nome;
	}

	public void IdDiagram(string id){
		this.idDiagram = id;
	}
		
	public void TypeDiagram(string type){
		this.typeDiagram = type;
	}


	void OnMouseDown(){
		//store in idDiagramLoaded the diagram id (PlayerPrefs work like GLOBAL VARIABLES)
		PlayerPrefs.SetString ("idDiagramLoaded" , this.idDiagram);
		//store the type of diagram (ex: Sequence, Activity ...)
		PlayerPrefs.SetString ("typeDiagramLoaded" , this.typeDiagram );

		//load the scene
		Application.LoadLevel ("SceneDiagram");
	}


	// Update is called once per frame
	void Update () {

	}
}
