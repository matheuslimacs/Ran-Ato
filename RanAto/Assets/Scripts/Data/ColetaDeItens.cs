using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColetaDeItens : MonoBehaviour {
	
    //Quantidade de moedas
	private int moedas;
    private int scrolls;

    public static bool hasUltimate = false;

    public GameObject contadorMoeda;
    public GameObject contadorScroll;

    private Text textoMoeda;
    private Text textoScroll;

    public AudioClip itemSound;
    public AudioSource gmAudio;

    private void Start()
    {
        textoMoeda = contadorMoeda.GetComponent<Text>();
        textoScroll = contadorScroll.GetComponent<Text>();
        gmAudio.clip = itemSound;
    }

    void OnTriggerEnter2D(Collider2D coll) {
		string tag = coll.gameObject.tag;
        
		switch (tag)
        {
	        case "Moeda":
                gmAudio.Play();
		        moedas++;
                Destroy(coll.gameObject);
                textoMoeda.text = moedas.ToString();
                break;
            case "Pergaminho":
                gmAudio.Play();
                scrolls++;
                Destroy(coll.gameObject);
                textoScroll.text = scrolls.ToString();
                break;
            case "Ultimate":
                Destroy(coll.gameObject);

                if (!hasUltimate)
                {
                    GameManager.specialIcon.color = new Color(255, 255, 255, 1f);
                    gmAudio.Play();
                    hasUltimate = true;
                }
                break;
		}
	}
}
