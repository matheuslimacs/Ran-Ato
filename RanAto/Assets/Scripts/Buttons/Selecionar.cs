using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Selecionar : MonoBehaviour {

    private Animation doorL;
    private Animation doorR;

    private bool tocou = false;

    private void Start()
    {
        tocou = false;
        doorL = GameObject.Find("doorL").GetComponent<Animation>();
        doorR = GameObject.Find("doorR").GetComponent<Animation>();
    }

    public void Japonesa()
    {
        if (!tocou)
        {
            tocou = true;
            GameManager.character = 1;
            StartCoroutine(GoToScene());
        }
    }

    public void Samurai()
    {
        if (!tocou)
        {
            tocou = true;
            GameManager.character = 2;
            StartCoroutine(GoToScene());
        }
    }

    public void Ninja()
    {
        if (!tocou)
        {
            tocou = true;
            GameManager.character = 3;
            StartCoroutine(GoToScene());
        }
    }

    private IEnumerator GoToScene()
    {
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainGame");
    }
}
