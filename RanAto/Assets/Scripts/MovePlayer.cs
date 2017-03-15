using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Esse script irá controlar os inputs do jogador, animações do personagem e afins

    private float moveSpeed = 7f;
    private float jumpSpeed;
    private bool bNoChao;
    public LayerMask groundLayer; // mostra quem é o chão nas layers
    private Rigidbody2D myRb; // adiciona ao myRb os componentes de um rigidbody
    private Collider2D myCollider;
    private Animator anim;

    private GameManager myPlayer; // Variável p/ referência da classe 'Player'.

    void Start ()
    {
        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        myPlayer = GameObject.Find("_GM").GetComponent<GameManager>();
        jumpSpeed = myPlayer.playerStats.JumpPower; // Setando o pulo para o valor atual do pulo, que varia caso o personagem seja a mulher, samurai ou ninja.
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
            Debug.Log("Pulando com força de " + jumpSpeed + "f!");
            myRb.velocity = new Vector2(myRb.velocity.x, jumpSpeed);
        }
    }
}
