using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int character = 3; // 1 - Mulher, 2 - Samurai, 3 - Ninja
    [HideInInspector]
    public PlayerStats playerStats = new PlayerStats(100, 8f, 3);

    public bool bGameStarted = false;
    public static bool bPause = false;
    public static bool bPlayerDead = false;

    private GameObject player;
    public GameObject doorL;
    public GameObject doorR;
    public GameObject gameover_sprite;
    public GameObject gameover_bg;

    public Animation doorLOut;
    public Animation doorROut;
    private Animation gameOverBGAnim;

    public GameObject menu;
    public GameObject playAgain;

    public Sprite[] iconesDoHud;
    public Sprite[] iconesDoJogo;
    public GameObject[] specialItems;

    private Image specialIcon;

    private void Awake()
    {
        specialIcon = GameObject.Find("ability_icon").GetComponent<Image>();
        specialItems = GameObject.FindGameObjectsWithTag("Ultimate");

        switch (character)
        {
            case 1:
                specialIcon.sprite = iconesDoHud[0];
                foreach (GameObject sprite in specialItems)
                {
                    sprite.GetComponent<SpriteRenderer>().sprite = iconesDoJogo[0];
                }
                break;
            case 2:
                specialIcon.sprite = iconesDoHud[1];
                foreach (GameObject sprite in specialItems)
                {
                    sprite.GetComponent<SpriteRenderer>().sprite = iconesDoJogo[1];
                }
                break;
            case 3:
                specialIcon.sprite = iconesDoHud[2];
                foreach (GameObject sprite in specialItems)
                {
                    sprite.GetComponent<SpriteRenderer>().sprite = iconesDoJogo[2];
                }
                break;
        }

        player = GameObject.Find("Player");
        gameOverBGAnim = gameover_bg.GetComponent<Animation>();
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

    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        if (ColetaDeItens.hasUltimate)
        {
            specialIcon.color = new Color(255, 255, 255, 1f);
        }
        else
        {
            specialIcon.color = new Color(255, 255, 255, 0.5f);
        }
    }

    private void GameStart()
    {
        StartCoroutine(DoorSlideOut());
    }

    private IEnumerator DoorSlideOut()
    {
        yield return new WaitForSeconds(1.5f);
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

    public void GameOver()
    {
        StartCoroutine(LoadGameOverUI());
    }

    public IEnumerator LoadGameOverUI()
    {
        yield return new WaitForSeconds(2f);
        gameOverBGAnim.Play("Tutorial_BGFadeIn");
        gameover_sprite.SetActive(true);
        menu.SetActive(true);
        playAgain.SetActive(true);
    }
}
