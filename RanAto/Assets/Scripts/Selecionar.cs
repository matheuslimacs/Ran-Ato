using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionar : MonoBehaviour {

    // O script abaixo não vai funcionar na versão Mobile.
    // Preciso que tu olhe como funciona o touch no jogo principal e tente implementar aqui (é simples).
    public GameObject samurai;
    public GameObject ninja;
    public GameObject menina;
    public int escolha;

    public void OnMouseDown(GameObject outro)
    {

        if (outro.CompareTag("Samurai"))
        {
            escolha = 1;
        }

        else if (outro.CompareTag("Ninja"))
        {
            escolha = 2;
        }

        else if (outro.CompareTag("Menina"))
        {
            escolha = 3;
        }
    }
}
