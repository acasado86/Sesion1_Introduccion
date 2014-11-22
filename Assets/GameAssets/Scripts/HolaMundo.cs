using UnityEngine;
using System.Collections;

public class HolaMundo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Hola Mundo!");
	}
		
	// Update is called once per frame
	void Update () {
		//Debug.Log("Update");
		
		Vector3 posicionActual = transform.position;
		posicionActual = posicionActual + new Vector3(0,0,-0.01f);
		transform.position = posicionActual;
	}
	
	void FixedUpdate()
	{
		//Debug.Log("FixedUpdate");
	}
}
