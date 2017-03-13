using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

    GameObject player;
    Animator anim;
    public RuntimeAnimatorController controller;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController = controller;
        anim.SetBool("isNinja", true);
        Debug.Log("It's me, ninja!");
    }
}
