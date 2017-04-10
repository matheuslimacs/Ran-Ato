using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

    public void IrAoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene("Selecao de Personagem");
    }
}
