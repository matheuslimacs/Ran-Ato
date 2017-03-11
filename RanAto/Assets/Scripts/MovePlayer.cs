using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Esse script irá controlar os inputs do jogador, animações do personagem e afins

    private float moveSpeed = 7f;
    private float jumpForce = 8f;
    private bool bNoChao;
    public LayerMask groundLayer; // mostra quem é o chão nas layers
    private Rigidbody2D myRb; // adiciona ao myRb os componentes de um rigidbody
    private Collider2D myCollider;
    private Animator anim;

	void Start ()
    {
        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();	
	}
	
	void FixedUpdate ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        bNoChao = Physics2D.IsTouchingLayers(myCollider, groundLayer);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Chao"))
        {
            anim.SetBool("Jump", false);
        }
    }

    public void Jump()
    {
        if (bNoChao)
        {
            anim.SetBool("Jump", true);
            Debug.Log("Pula!");
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        }
    }
}
