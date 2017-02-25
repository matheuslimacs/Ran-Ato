using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    // Esse script irá acompanhar o jogador em seu movimento.

    private float moveSpeed = 7f;
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
