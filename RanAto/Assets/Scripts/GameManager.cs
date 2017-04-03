using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static int character = 1; // 1 - Mulher, 2 - Samurai, 3 - Ninja
    [HideInInspector]
    public PlayerStats playerStats = new PlayerStats(100, 8f, 3);
    public bool bGameStarted = false;

    private GameObject player;
    public GameObject doorL;
    public GameObject doorR;

    public Animation doorLOut;
    public Animation doorROut;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        GameStart();

        switch (character)
        {
            case 1: // Mulher
                EnableWomanScript();
                DefinePlayer(115, 8f, 0);
                Debug.Log("Personagem criado: Mulher - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
                break;
            case 2: // Samurai
                EnableSamuraiScript();
                DefinePlayer(150, 10f, 3);
                Debug.Log("Personagem criado: Samurai - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
                break;
            case 3: // Ninja
                EnableNinjaScript();
                DefinePlayer(130, 12f, 5);
                Debug.Log("Personagem criado: Ninja - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
                break;
        }
    }

    // Apenas 'travando' a tela na orientação Retrato.
    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void GameStart()
    {
        StartCoroutine(DoorSlideOut());
    }

    private IEnumerator DoorSlideOut()
    {
        doorLOut.Play();
        doorROut.Play();
        yield return new WaitForSeconds(0.5f);
        bGameStarted = true;
        doorL.gameObject.SetActive(false);
        doorR.gameObject.SetActive(false);
    }

    void DefinePlayer(int hp, float jmpPower, int am)
    {
        playerStats.Health = hp;
        playerStats.JumpPower = jmpPower;
        playerStats.Ammo = am;
    }

    void EnableWomanScript()
    {
        player.GetComponent<Woman>().enabled = true;
        player.GetComponent<Samurai>().enabled = false;
        player.GetComponent<Ninja>().enabled = false;
    }

    void EnableSamuraiScript()
    {
        player.GetComponent<Woman>().enabled = false;
        player.GetComponent<Samurai>().enabled = true;
        player.GetComponent<Ninja>().enabled = false;
    }

    void EnableNinjaScript()
    {
        player.GetComponent<Woman>().enabled = false;
        player.GetComponent<Samurai>().enabled = false;
        player.GetComponent<Ninja>().enabled = true;
    }
}
