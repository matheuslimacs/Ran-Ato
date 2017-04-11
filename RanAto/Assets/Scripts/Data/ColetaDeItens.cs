using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColetaDeItens : MonoBehaviour {
	
    //Quantidade de moedas
	private int moedas;
    private int scrolls;

    public GameObject contadorMoeda;
    public GameObject contadorScroll;

    private Text textoMoeda;
    private Text textoScroll;

    private void Start()
    {
        textoMoeda = contadorMoeda.GetComponent<Text>();
        textoScroll = contadorScroll.GetComponent<Text>();
    }

    //Verifica a Colisao se o jogador colidiu com algum item e seleciona o efeito.
    void OnTriggerEnter2D(Collider2D coll) {
		string tag = coll.gameObject.tag;
		//Faz uma selecao de qual item foi coletado e chama a funcao correspondente.
		switch (tag)
        {
		case "Moeda":
			moedas++;
            Destroy(coll.gameObject);
            textoMoeda.text = moedas.ToString();
            break;
        case "Pergaminho":
            scrolls++;
            Destroy(coll.gameObject);
            textoScroll.text = scrolls.ToString();
            break;
		}
		//Esperando efeitos dos itens para colocar os codigos.
		//Esperando Estudo de dados persistentes para corrigir o codigo de maneira melhor.

	}
}
