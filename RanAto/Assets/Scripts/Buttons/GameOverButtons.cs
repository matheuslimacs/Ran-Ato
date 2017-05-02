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
        PlayGame();
        RepositionPlayerAndCamera();
        ActivateItems();
        ResetUI();
    }

    void ActivateItems()
    {
        foreach (GameObject item in ColetaDeItens.disabledItems)
        {
            if (item)
            {
                item.SetActive(true);
            }           
        }

        ColetaDeItens.disabledItems.Clear();
    }

    void ResetUI()
    {
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
        ColetaDeItens.moedas = 0;
        ColetaDeItens.scrolls = 0;
        ColetaDeItens.textoMoeda.text = ColetaDeItens.moedas.ToString();
        ColetaDeItens.textoScroll.text = ColetaDeItens.scrolls.ToString();
        ColetaDeItens.hasUltimate = false;
        bg_tutorial.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        menu_button.SetActive(false);
        gameover_sprite.SetActive(false);

        GameManager.specialIcon.color = new Color(255, 255, 255, 0.5f);
    }

    void RepositionPlayerAndCamera()
    {
        player.position = playerStartPos.position;
        mainCam.transform.position = camStartPos.position;
    }

    public void PlayGame()
    {
        GameManager.bPause = false;
        gameObject.SetActive(false);
    }
}
