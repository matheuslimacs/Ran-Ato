using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDados : ScriptableObject {

	//Variaveis contendo os dados.
	private  int tMoedas;
	private  int distancia;
	private  int mDistancia;

	//Propriedade da distancia.
	public int Distancia{
		get{
			return distancia;
		}
		set{ 
			distancia = value;
		}
	}

	//Propriedade das moedas
	public int TMoedas{
		get{
			return tMoedas;
		}
		set{ 
			tMoedas = value;
		}
	}

	// Funcão cridada para atualizar os dados da tela.
	//Essa função deverá ser chamada todo final de fase.
	public static void CarregaDados(){
		mDistancia = PlayerPrefs.GetInt ("mDistancia");
		tMoedas = PlayerPrefs.GetInt ("tMoedas");
	}

	//Função cridada para verificar e salvar os dados das moedas e da maior distância.
	public static void SalvaDados ()
	{
		if (distancia >= mDistancia) {
			mDistancia = distancia;
			PlayerPrefs.SetInt ("mDistancia", mDistancia);
		}
		PlayerPrefs.SetInt ("tMoedas",tMoedas);
	}
}