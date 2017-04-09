using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour {

    GameObject player;
    Animator anim;
    public RuntimeAnimatorController controller;

    private SpriteRenderer sprtRender;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        sprtRender = GetComponent<SpriteRenderer>();
        sprtRender.flipX = true;
        anim.runtimeAnimatorController = controller;
        Debug.Log("It's me, samurai!");
    }
}
