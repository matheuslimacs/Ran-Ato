using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour {

    public Transform playerStartPos;
    public Transform camStartPos;
    public Transform player;

    public Animation doorR;
    public Animation doorL;

    public GameObject bg_tutorial;
    public GameObject menu_button;
    public GameObject gameover_sprite;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void IrAoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void JogarNovamente()
    {
        StartCoroutine(SlideDoors());
        RepositionPlayerAndCamera();
        ActivateItems();
        ResetUI();
    }

    void ActivateItems()
    {
        foreach (GameObject item in ColetaDeItens.disabledItems)
        {
            item.SetActive(true);
        }

        ColetaDeItens.disabledItems.Clear();
    }

    void ResetUI()
    {
        ColetaDeItens.moedas = 0;
        ColetaDeItens.scrolls = 0;
        ColetaDeItens.textoMoeda.text = ColetaDeItens.moedas.ToString();
        ColetaDeItens.textoScroll.text = ColetaDeItens.scrolls.ToString();
        ColetaDeItens.hasUltimate = false;
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
        bg_tutorial.SetActive(false);
        menu_button.SetActive(false);
        gameover_sprite.SetActive(false);

        GameManager.specialIcon.color = new Color(255, 255, 255, 0.5f);
    }

    void RepositionPlayerAndCamera()
    {
        player.position = playerStartPos.position;
        mainCam.transform.position = camStartPos.position;
    }

    public IEnumerator SlideDoors()
    {
        doorL.gameObject.SetActive(true);
        doorR.gameObject.SetActive(true);
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
        yield return new WaitForSeconds(1.0f);
        doorL.Play("DoorLSlideOut");
        doorR.Play("DoorRSlideOut");        
        GameManager.bPause = false;
        gameObject.SetActive(false);
        doorL.gameObject.SetActive(false);
        doorR.gameObject.SetActive(false);
    }
}
