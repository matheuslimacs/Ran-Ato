using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

    GameObject player;
    Animator anim;
    SpriteRenderer sprtRender;

    public RuntimeAnimatorController controller;
    public GameObject shurikenPrefab;

    public GameObject shurikenSpawnLocation;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController = controller;
        sprtRender = GetComponent<SpriteRenderer>();
        Debug.Log("It's me, ninja!");
        sprtRender.flipX = true;
    }

    private void Update()
    {
        if (GameManager.character == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(shurikenPrefab, shurikenSpawnLocation.transform.position, shurikenSpawnLocation.transform.rotation);
            }
        }
    }
}
