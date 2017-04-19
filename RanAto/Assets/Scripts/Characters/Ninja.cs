using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

    GameObject player;
    Animator anim;
    SpriteRenderer sprtRender;

    public RuntimeAnimatorController controller;

    public static int ninjaAmmo;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController = controller;
        sprtRender = GetComponent<SpriteRenderer>();
        sprtRender.flipX = true;
    }
}
