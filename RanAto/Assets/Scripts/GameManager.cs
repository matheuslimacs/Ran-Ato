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
                player.GetComponent<Woman>().enabled = true;
                player.GetComponent<Samurai>().enabled = false;
                player.GetComponent<Ninja>().enabled = false;

                playerStats.Health = 115;
                playerStats.JumpPower = 5f;
                playerStats.Ammo = 0;
                break;
            case 2: // Samurai
                player.GetComponent<Woman>().enabled = false;
                player.GetComponent<Samurai>().enabled = true;
                player.GetComponent<Ninja>().enabled = false;

                playerStats.Health = 150;
                playerStats.JumpPower = 8f;
                playerStats.Ammo = 3;
                break;
            case 3: // Ninja
                player.GetComponent<Woman>().enabled = false;
                player.GetComponent<Samurai>().enabled = false;
                player.GetComponent<Ninja>().enabled = true;

                playerStats.Health = 130;
                playerStats.JumpPower = 12f;
                playerStats.Ammo = 5;
                break;
        }
    }

}
