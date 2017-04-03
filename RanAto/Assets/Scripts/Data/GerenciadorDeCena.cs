using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour {

	//Funcao que verifica qual a cena atual do jogo e recarrega a mesma.
	public void Restart(){
		//Verifica qual a cena.
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}
	//Funcao que carrega a cena do Menu Principal.
	public void MenuPrincipal(){
		
		SceneManager.LoadScene ("MenuPrincipal");
	
	}

	//Sai do Jogo
	public void SairDoJogo(){

		Application.Quit ();

	}
}
