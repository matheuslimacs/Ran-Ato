using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawning : MonoBehaviour {

    // Esse script irá posicionar corretamente cada plataforma na frente da outra.

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public GroundPooler objPool;

    private void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    private void Update()
    {
        if (transform.position.x > generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x - platformWidth, transform.position.y, transform.position.z);

            GameObject newPlatform = objPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
