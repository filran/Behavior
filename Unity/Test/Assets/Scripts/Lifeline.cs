using UnityEngine;
using System.Collections;

public class Lifeline : MonoBehaviour {

	public float velovidadeLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = transform.localScale + Vector3.forward * velovidadeLife * Time.deltaTime;
	}
}
