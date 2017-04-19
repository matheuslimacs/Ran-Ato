using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaveisScript : MonoBehaviour {

    int coletavel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Coletaveis"))
        {
            Destroy(other.gameObject);
            coletavel += 1;
        }
    }
}
