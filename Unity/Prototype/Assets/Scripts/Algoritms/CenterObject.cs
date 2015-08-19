using UnityEngine;
using System.Collections;

public class CenterObject : MonoBehaviour {

	public GameObject MyObject;
	public float countMyObject;
	private float widthMyObject;
	public float widthSpace;
	private float countSpace;
	private float sumWidthMyObject;
	private float sumWidthSpace;
	private float sumWidth;
	private float firstPoint;

	// Use this for initialization
	void Start () {
		this.widthMyObject = MyObject.transform.localScale.x;
		this.countSpace = countMyObject - 1;
		this.sumWidthMyObject = widthMyObject * countMyObject;
		this.sumWidthSpace = widthSpace * countSpace;
		this.sumWidth = sumWidthMyObject + sumWidthSpace;
		this.firstPoint = (sumWidth / 2) - (sumWidth - 1);

		Debug.Log ( "Largura do Objeto: " + widthMyObject );
		Debug.Log ( "Largura do Espaço:"  + widthSpace);
		Debug.Log ( "Qtd de Objetos: "  + countMyObject);
		Debug.Log ( "Qtd de Espaços: "  + countSpace);
		Debug.Log ( "TotalLarguraObjects: "  + sumWidthMyObject);
		Debug.Log ( "TotalLArguraEspaço: "  + sumWidthSpace );
		Debug.Log ( "Total Largura: "  + sumWidth );
		Debug.Log ( "Primeiro Ponto"  + firstPoint);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
