using UnityEngine;
using System.Collections;

public class Program : MonoBehaviour {

	public GameObject ObjFile;
	public int qtd;


	// Use this for initialization
	void Start () {

		for(int i=1; i<=qtd; i++)
		{
			float posX = ObjFile.transform.position.y + ( 3 * i );
			Vector3 pos = new Vector3 ( posX , ObjFile.transform.position.y , ObjFile.transform.position.z );

			Instantiate(ObjFile , pos, Quaternion.identity );
		}

	
	}
	
	// Update is called once per frame
	void Update () {



	}
}
