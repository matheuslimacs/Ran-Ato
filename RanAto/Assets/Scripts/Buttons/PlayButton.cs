using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    public Animation doorL;
    public Animation doorR;

    private Animator scrollFolding;

    private AudioSource woodSfx;

    private Text buttonText;

    private bool tocou = false;

    private void Start()
    {
        tocou = false;
        woodSfx = GetComponent<AudioSource>();
        scrollFolding = GetComponent<Animator>();
        buttonText = GetComponentInChildren<Text>();
    }

    public void Historia()
    {
        if (!tocou)
        {
            tocou = true;
            StartCoroutine(GoToScene());
            buttonText.text = "";
            woodSfx.Play();
            scrollFolding.Play("ScrollFoldingBack");
        }
    }

    private IEnumerator GoToScene()
    {
        doorL.Play();
        doorR.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Selecao de Personagem");
    }
}
