using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

    public Transform playerStartPos;
    public Transform player;

    public Animation doorR;
    public Animation doorL;

    public void IrAoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void JogarNovamente()
    {
        StartCoroutine(SlideDoors());
        RepositionPlayer();
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

        GameManager.specialIcon.color = new Color(255, 255, 255, 0.5f);
    }

    void RepositionPlayer()
    {
        player.position = playerStartPos.position;
    }

    public IEnumerator SlideDoors()
    {
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
        yield return new WaitForSeconds(1.0f);
        doorL.Play("DoorLSlideOut");
        doorR.Play("DoorRSlideOut");
    }
}
