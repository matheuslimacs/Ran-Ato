using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {
    public int ouro;
	// Use this for initialization
	void Start () {
        ouro = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gold"))
        {
            Destroy(other.gameObject);
            ouro += 1;
        }
    }
}
