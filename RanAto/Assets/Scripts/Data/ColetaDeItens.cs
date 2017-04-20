using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ColetaDeItens : MonoBehaviour {
	
    //Quantidade de moedas
	public static int moedas;
    public static int scrolls;

    public static bool hasUltimate = false;

    public GameObject contadorMoeda;
    public GameObject contadorScroll;

    public static Text textoMoeda;
    public static Text textoScroll;

    public AudioClip itemSound;
    public AudioSource gmAudio;

    public static List<GameObject> disabledItems = new List<GameObject>();

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
                coll.gameObject.SetActive(false);
                disabledItems.Add(coll.gameObject);
                textoMoeda.text = moedas.ToString();
                break;
            case "Pergaminho":
                gmAudio.Play();
                scrolls++;
                coll.gameObject.SetActive(false);
                disabledItems.Add(coll.gameObject);
                textoScroll.text = scrolls.ToString();
                break;
            case "Ultimate":
                coll.gameObject.SetActive(false);
                disabledItems.Add(coll.gameObject);

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
