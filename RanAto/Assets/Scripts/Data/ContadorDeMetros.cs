using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeMetros : MonoBehaviour {

    //Variavel que irá contar a distancia atual.
    public int metros;    
	
	// Contagem criada para somar +1 a variavel metros a cada frame.
	void Update () {
        metros++;
	}
}