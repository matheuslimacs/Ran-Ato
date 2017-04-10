using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteScript : MonoBehaviour {

    public ParticleSystem deathParticle;
    private GameManager GMSCript;

    private void Start()
    {
        GMSCript = GameObject.Find("_GM").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Caixa"))
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            GameManager.bPlayerDead = true;
            GMSCript.GameOver();
            Destroy(gameObject);
        }
    }
}
