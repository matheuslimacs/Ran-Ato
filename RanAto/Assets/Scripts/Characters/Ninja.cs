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

    public static int ninjaAmmo;

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
            if (Input.touchCount > 0)
            {
                RaycastHit2D hit;

                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

                if (hit.collider != null && hit.transform.gameObject.name == "Ability_icon" && ninjaAmmo > 0)
                {
                    Instantiate(shurikenPrefab, shurikenSpawnLocation.transform.position, shurikenSpawnLocation.transform.rotation);
                }
            }
        }
    }
}
