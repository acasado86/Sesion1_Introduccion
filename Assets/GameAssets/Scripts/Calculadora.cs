using UnityEngine;
using System.Collections;

public class Calculadora : MonoBehaviour {
	
	public float margenSuperior = 50;
	public float margenIzquierdo = 50;	
	public float margenBoton = 10;
	
	public float anchoBoton = 50;
	public float altoBoton = 50;
	
	string resultado = "0";
	int resultadoInterno = 0;
	string operacion="+";
	
	bool tengoQueResetear = true;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		GUI.Label(new Rect(margenIzquierdo,margenSuperior,170,50), resultado);
		
		//Numero del 1 al 9
		for(int fila = 0; fila < 3; fila++){			
			for(int columna = 0; columna < 3; columna++){
				int numero = 1 + 3 * (2-fila) + columna;				
				float x = margenIzquierdo + columna * (anchoBoton + margenBoton);
				float y = margenSuperior + 50 + fila * (altoBoton + margenBoton);			
				Rect rectangulo = new Rect(x,y,anchoBoton,altoBoton);
				if(GUI.Button(rectangulo,numero.ToString()))
				{
					if(tengoQueResetear) { 
						resultado = ""; 
						tengoQueResetear = false;
					}
					resultado = resultado + numero.ToString();
				}
			}			
		}
		
		//Operaciónes matemáticas
		//SUMA
		float xSuma = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float ySuma = margenSuperior + 2 * (margenBoton+anchoBoton) + 50;
		Rect rectSuma = new Rect(xSuma, ySuma, anchoBoton, altoBoton);
		if (GUI.Button(rectSuma, "+")) {
			if (!tengoQueResetear)
				CalcularResultado();
			tengoQueResetear = true;
			operacion="+";
			resultado=resultadoInterno.ToString();
		}
		
		
		//RESTA
		float xResta = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float yResta = margenSuperior + 1 * (margenBoton+anchoBoton) + 50;
		Rect rectResta = new Rect(xResta, yResta, anchoBoton, altoBoton);
		if (GUI.Button(rectResta, "-")) {
			if (!tengoQueResetear)
				CalcularResultado();
			tengoQueResetear = true;
			operacion="-";
			resultado=resultadoInterno.ToString();
		}
		
		
	}
	
	void CalcularResultado(){
		switch(operacion){
		case "+":
			resultadoInterno += int.Parse(resultado);
			resultado=resultadoInterno.ToString();
			break;
		case "-":
			resultadoInterno -= int.Parse(resultado);
			resultado=resultadoInterno.ToString();
			break;
		}
	}
}
