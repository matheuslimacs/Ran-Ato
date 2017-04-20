using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteScript : MonoBehaviour {

    private GameManager GMSCript;

    private MovePlayer player;

    public AudioSource gmAudio;

    public AudioClip dummy_death;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        GMSCript = GameObject.Find("_GM").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.character == 2 && player.GetComponent<Animator>().GetBool("Ultimate") && other.collider.CompareTag("Inimigos"))
        {
            gmAudio.clip = dummy_death;
            gmAudio.Play();
            other.gameObject.SetActive(false);
            ColetaDeItens.disabledItems.Add(other.gameObject);
        }

        else if (other.collider.CompareTag("Caixa") || other.collider.CompareTag("Inimigos") && !player.GetComponent<Animator>().GetBool("Ultimate"))
        {
            GameManager.bPlayerDead = true;
            GMSCript.GameOver();
            gameObject.SetActive(false);
            ColetaDeItens.disabledItems.Add(gameObject);
        }
    }
}
