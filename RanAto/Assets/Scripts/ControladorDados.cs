using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Classe Criada para gerenciar os dados que iram continuar no jogo apos fechar.
 * Total de moedas e maior distancia serão carregados quando o jogo começar e serão salvos quando a fase terminar.
 * Esperando limite das fases para chamar as funções na hora certa. 
 */
public class ControladorDados : MonoBehaviour {

	//Instancia criada para uso.
	public static ControladorDados controlador;

	//Variaveis contendo os dados.
	private static int tMoedas;
	private static int distancia;
	private static int mDistancia;

	//Será criado o controlador no inicio do jogo.
	void Aweke(){

		if (!(controlador is ControladorDados) || controlador == null) {
			controlador = this;
		}
	}

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