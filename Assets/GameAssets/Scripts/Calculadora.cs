using UnityEngine;
using System.Collections;

public class Calculadora : MonoBehaviour {
	
	public float margenSuperior = 50;
	public float margenIzquierdo = 50;	
	public float margenBoton = 10;
	
	public float anchoBoton = 50;
	public float altoBoton = 50;
	
	float altoResultado = 50;
	
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
		float anchoResultado = 3*anchoBoton + 2*margenBoton;
		GUI.Label(new Rect(margenIzquierdo,margenSuperior,anchoResultado,altoResultado), resultado);
		
		//Numero del 1 al 9
		for(int fila = 0; fila < 3; fila++){			
			for(int columna = 0; columna < 3; columna++){
				int numero = 1 + 3 * (2-fila) + columna;				
				Rect rectangulo = RectanguloFilaColumna(fila+1, columna+1);
				PintarNumero(rectangulo, numero);
			}			
		}
		
		//Numero Cero
		float xCero = margenIzquierdo;
		float yCero = margenSuperior + 3 * (margenBoton+altoBoton) + altoResultado;
		Rect rectCero = new Rect(xCero, yCero, (3*anchoBoton + 2*margenBoton), altoBoton);
		PintarNumero(rectCero, 0);
		
		//Operaciónes matemáticas y reset
		//float colCuatro = margenIzquierdo + 3 * (margenBoton+anchoBoton);
		
		//RESET	
		Rect rectReset = RectanguloFilaColumna(1, 4);
		if (GUI.Button(rectReset, "CE")) {
			resultadoInterno=0;
			resultado = "0";
			tengoQueResetear = true;
			operacion="+";
		}
		
		//SUMA
		Rect rectSuma = RectanguloFilaColumna(3, 4);
		PintarOperador(rectSuma, "+");
		
		
		//RESTA
		Rect rectResta = RectanguloFilaColumna(2, 4);
		PintarOperador(rectResta, "-");
		
		//IGUAL
		Rect rectIgual = RectanguloFilaColumna(4, 4);
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
	
	Rect RectanguloFilaColumna(int fila, int columna){
		float x = margenIzquierdo + (columna - 1) * (anchoBoton + margenBoton);
		float y = margenSuperior + altoResultado + (fila- 1) * (altoBoton + margenBoton);
		Rect rectangulo = new Rect(x, y, anchoBoton, altoBoton);
		return rectangulo;
	}
}
