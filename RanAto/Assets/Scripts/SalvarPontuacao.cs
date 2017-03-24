using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvarPontuacao : MonoBehaviour {
    
    // TODO: Incluir variável para salvar dados do ouro coletado
    public int distancia;
    public int maiorDistancia;

	// Use this for initialization
	void Start () {
        distancia = 0;
        maiorDistancia = 0;
	}
	
	// Update is called once per frame
	void Update () {
        distancia = distancia + 1;
        
        if (distancia >= maiorDistancia)
        {
            maiorDistancia = distancia;
            PlayerPrefs.SetInt("mDistancia", maiorDistancia);
        }
	}

    
}
