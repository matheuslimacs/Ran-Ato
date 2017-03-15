using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static int character = 3; // 1 - Mulher, 2 - Samurai, 3 - Ninja
    public PlayerStats.Player playerStats = new PlayerStats.Player(100, 8f, 3);

    private GameObject player;
    // A variável acima armazena o objeto do jogador
    // Dessa forma, poderemos organizar qual script ativar (mulher, samurai ou ninja) a depender da escolha do jogador.

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        switch (character)
        {
            case 1: // Mulher
                EnableWomanScript();
                DefinePlayer(115, 5f, 0);
                Debug.Log("Personagem criado: Mulher - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
                break;
            case 2: // Samurai
                EnableSamuraiScript();
                DefinePlayer(150, 8f, 3);
                Debug.Log("Personagem criado: Samurai - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
                break;
            case 3: // Ninja
                EnableNinjaScript();
                DefinePlayer(130, 12f, 5);
                Debug.Log("Personagem criado: Ninja - Vida: " + playerStats.Health + " - Jump Power: " + playerStats.JumpPower);
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
}
