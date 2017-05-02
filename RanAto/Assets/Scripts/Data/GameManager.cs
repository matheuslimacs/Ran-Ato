using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int character = 1; // 1 - Mulher, 2 - Samurai, 3 - Ninja

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

    public static Image specialIcon;

    private void Awake()
    {
        player = GameObject.Find("Player");
        specialIcon = GameObject.Find("ability_icon").GetComponent<Image>();
        specialItems = GameObject.FindGameObjectsWithTag("Ultimate");
        gameOverBGAnim = gameover_bg.GetComponent<Animation>();

        ChangeSpecialAbilityIcon();
    }

    private void Start()
    {
        GameStart();
        ChooseCharacter();
    }

    private void GameStart()
    {
        StartCoroutine(DoorSlideOut());
    }

    public void GameOver()
    {
        StartCoroutine(LoadGameOverUI());
    }

    void ChooseCharacter()
    {
        switch (character)
        {
            case 1: // Mulher
                EnableWomanScript();
                DefinePlayer(115, 20f, 0);
                break;
            case 2: // Samurai
                EnableSamuraiScript();
                DefinePlayer(150, 25f, 3);
                break;
            case 3: // Ninja
                EnableNinjaScript();
                DefinePlayer(130, 28f, 5);
                break;
        }
    }

    void ChangeSpecialAbilityIcon()
    {
        specialIcon.color = new Color(255, 255, 255, 0.5f);

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


    private IEnumerator DoorSlideOut()
    {
        bPause = true;
        yield return new WaitForSeconds(0.5f);
        doorLOut.Play();
        doorROut.Play();
        yield return new WaitForSeconds(0.35f);
        bPause = false;
        bGameStarted = true;
        doorL.gameObject.SetActive(false);
        doorR.gameObject.SetActive(false);
    }

    public IEnumerator LoadGameOverUI()
    {
        yield return new WaitForSeconds(1f);
        gameOverBGAnim.Play("Tutorial_BGFadeIn");
        gameover_sprite.SetActive(true);
        menu.SetActive(true);
        playAgain.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        playAgain.SetActive(true);
    }
}
