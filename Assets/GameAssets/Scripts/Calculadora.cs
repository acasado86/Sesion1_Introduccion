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
				PintarNumero(rectangulo, numero);
			}			
		}
		
		//Numero Cero
		float xCero = margenIzquierdo;
		float yCero = margenSuperior + 3 * (margenBoton+altoBoton) + 50;
		Rect rectCero = new Rect(xCero, yCero, (3*anchoBoton + 2*margenBoton), altoBoton);
		PintarNumero(rectCero, 0);
		
		//Operaciónes matemáticas y reset
		float colCuatro = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		
		//RESET	
		//float xSuma = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float yReset = margenSuperior + 0 * (margenBoton+anchoBoton) + 50;
		Rect rectReset = new Rect(colCuatro, yReset, anchoBoton, altoBoton);
		if (GUI.Button(rectReset, "CE")) {
			resultadoInterno=0;
			resultado = "0";
			tengoQueResetear = true;
			operacion="+";
		}
		
		//SUMA	
		//float xSuma = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float ySuma = margenSuperior + 2 * (margenBoton+anchoBoton) + 50;
		Rect rectSuma = new Rect(colCuatro, ySuma, anchoBoton, altoBoton);
		PintarOperador(rectSuma, "+");
		
		
		//RESTA
		//float xResta = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float yResta = margenSuperior + 1 * (margenBoton+anchoBoton) + 50;
		Rect rectResta = new Rect(colCuatro, yResta, anchoBoton, altoBoton);
		PintarOperador(rectResta, "-");
		
		//IGUAL
		//float xIgual = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		float yIgual = margenSuperior + 3 * (margenBoton+anchoBoton) + 50;
		Rect rectIgual = new Rect(colCuatro, yIgual, anchoBoton, altoBoton);
		PintarOperador(rectIgual, "=");
		
		
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
	
	void PintarNumero(Rect rectangulo, int numero){
		if(GUI.Button(rectangulo,numero.ToString()))
		{
			if(tengoQueResetear) { 
				resultado = ""; 
				tengoQueResetear = false;
			}
			if (resultado!="0")
				resultado = resultado + numero.ToString();
			else
				resultado=numero.ToString();
		}
	}
	
	void PintarOperador(Rect rectangulo, string operador){
		if (GUI.Button(rectangulo, operador)) {
			if (!tengoQueResetear)
				CalcularResultado();
			tengoQueResetear = true;
			operacion=operador;
		}
	}
}
