using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 100f;
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	private bool dobleSaltoUtilizado = false;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate(){
	

		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	
		if(enSuelo){
			dobleSaltoUtilizado = false;
		}


	}

	// Update is called once per frame
	void Update () { //Aqui actualizamos el estado de todos los objetos antes de dibujar el fotograma
				//La utilizaremos para comprobar si se ha tocado la pantalla o el boton izquierdo del raton
	
		if (Input.GetMouseButtonDown (0) && (enSuelo || dobleSaltoUtilizado == false )) { //Si se ha pulsado el bton izquierdo del raton
											//Tambien vale como pulsacion de la pantalla del movil
		

			//Vamos a aplicar una fuerza aplicando el RigidBody
			GetComponent<Rigidbody2D>().velocity=new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
		//Addforce requiere un Vector2 con las coordenadas x e y
			//En la x no queremos aplicar ninguna fuerza asi que ponemos un 0
			//En la y (hace arriba) aplicamos la fuerza que tengamos en la variable fuerzaSalto
			dobleSaltoUtilizado =true;

		}
	}

}
