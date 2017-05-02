using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject tutorial_sprite;
    public GameObject tutorial_bg;

    private GameObject[] desativarInimigos;

    public Sprite ataque;

    private Animation tutoSprtAnim;
    private Animation tutoBGAnim;

    public static bool fezTutorialPulo = false;
    public static bool tutorialPuloExibido = false;
    public static bool fezTutorialAtaque = false;
    public static bool tutorialAtaqueExibido = false;

    private void Start()
    {
        tutoSprtAnim = tutorial_sprite.GetComponent<Animation>();
        tutoBGAnim = tutorial_bg.GetComponent<Animation>();

        if (GameManager.character == 1)
        {
            if (GameObject.Find("TutorialTrigger02"))
            {
                GameObject.Find("TutorialTrigger02").SetActive(false);
            }

            desativarInimigos = GameObject.FindGameObjectsWithTag("Inimigos");

            foreach (GameObject inimigo in desativarInimigos)
            {
                inimigo.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") && !fezTutorialPulo && gameObject.name == "TutorialTrigger01")
        {
            GameManager.bPause = true;
            tutoSprtAnim.Play("PuloTutorialFadeIn");
            tutoBGAnim.Play("Tutorial_BGFadeIn");
            tutorialPuloExibido = true;
        }

        if (collision.gameObject.tag == ("Player") && !fezTutorialAtaque && gameObject.name == "TutorialTrigger02" && GameManager.character != 1)
        {
            GameManager.bPause = true;
            tutorial_sprite.GetComponent<SpriteRenderer>().sprite = ataque;
            tutoSprtAnim.Play("PuloTutorialFadeIn");
            tutoBGAnim.Play("Tutorial_BGFadeIn");
            tutorialAtaqueExibido = true;
        }
    }

    public void FezTutorial()
    {
        tutoSprtAnim.Play("PuloTutorialFadeOut");
        tutoBGAnim.Play("Tutorial_BGFadeOut");
    }
}
