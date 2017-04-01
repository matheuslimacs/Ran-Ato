using UnityEngine;
using System.Collections;

public class ColetaDeItens : MonoBehaviour {
	
    //Quantidade de moedas
	public int moedas;
    
	//Verifica a Colisao se o jogador colidiu com algum item e seleciona o efeito.
	void OnCollisionEnter2D(Collision2D coll) {
		string nome = coll.gameObject.name;
		//Faz uma selecao de qual item foi coletado e chama a funcao correspondente.
		switch (nome){

		//seleciona o Moedas e executa a funcao.
		case "Moedas":
			moedas++;
            break;
		}
		//Esperando efeitos dos itens para colocar os codigos.
		//Esperando Estudo de dados persistentes para corrigir o codigo de maneira melhor.

	}
}
