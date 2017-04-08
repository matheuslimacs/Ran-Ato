using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject tutorial_sprite;
    public GameObject tutorial_bg;

    private Animation tutoSprtAnim;
    private Animation tutoBGAnim;

    public static bool fezTutorialPulo = false;
    public static bool tutorialExibido = false;

    private void Start()
    {
        tutoSprtAnim = tutorial_sprite.GetComponent<Animation>();
        tutoBGAnim = tutorial_bg.GetComponent<Animation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") && !fezTutorialPulo)
        {
            GameManager.bPause = true;
            tutoSprtAnim.Play("PuloTutorialFadeIn");
            tutoBGAnim.Play("Tutorial_BGFadeIn");
            tutorialExibido = true;
        }
    }

    private void Update()
    {
        if (fezTutorialPulo)
        {

        }
    }

    public void FezTutorialPulo()
    {
        tutoSprtAnim.Play("PuloTutorialFadeOut");
        tutoBGAnim.Play("Tutorial_BGFadeOut");
    }
}
