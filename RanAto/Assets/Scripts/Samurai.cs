using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour {

    GameObject player;
    Animator anim;
    public RuntimeAnimatorController controller;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController = controller;
        Debug.Log("It's me, samurai!");
    }
}
