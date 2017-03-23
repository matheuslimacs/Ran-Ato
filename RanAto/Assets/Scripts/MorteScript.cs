using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteScript : MonoBehaviour {
    public int vivo;

	// Use this for initialization
	void Start () {
        vivo = 5;
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigos"))
        {
            vivo--;
        }

        if (vivo <= 0)
        {
            // TODO: Carregar tela de game over
        }
    }
}
