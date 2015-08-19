using UnityEngine;
using System.Collections;

public class ObjLife : MonoBehaviour {

	public GameObject Obj;
	public GameObject Life;
	public float velocidade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Obj.transform.localScale = Obj.transform.localScale + Obj.transform.forward * velocidade * Time.deltaTime;
//		Life.transform.localScale = Life.transform.localScale + Life.transform.forward * velocidade * Time.deltaTime;

//		float posYlife = Life.transform.forward + Life.transform.position.y * velocidade * Time.deltaTime;
//		Life.transform.localScale = new Vector3 (Life.transform.localScale.x, Life.transform.localScale.y + velocidade * Time.deltaTime,Life.transform.localScale.z);

		if( Life.transform.localScale.y > 6.0f )
		{
			Life.transform.localScale = new Vector3 (Life.transform.localScale.x, 6.0f ,Life.transform.localScale.z);
		}



		Debug.Log ( "X:"+Life.transform.localScale.x );
		Debug.Log ( "Y:"+Life.transform.localScale.y );
		Debug.Log ( "Z:"+Life.transform.localScale.z );
		Debug.Log ( Life.transform.localScale.y + velocidade * Time.deltaTime );
	}
}
