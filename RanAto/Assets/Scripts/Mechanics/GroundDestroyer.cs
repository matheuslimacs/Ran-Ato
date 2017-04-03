using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {

    // Esse script irá desativar as plataformas que não estão em uso para poupar memória.

    public GameObject platformDestructionPoint;

    private void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    private void Update()
    {
        if (transform.position.x > platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
