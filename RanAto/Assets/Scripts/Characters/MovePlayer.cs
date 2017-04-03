using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Esse script irá controlar os inputs do jogador, animações do personagem e afins
    private float moveSpeed = 7f;
    private float jumpSpeed = 0;

    private int jmpCounter = 0;

    private bool bNoChao;
    public bool isGoingDown;

    public LayerMask groundLayer; // mostra quem é o chão nas layers
    private Rigidbody2D myRb; // adiciona ao myRb os componentes de um rigidbody
    private Collider2D myCollider;
    private Animator anim;

    private GameManager myPlayer; // Variável p/ referência da classe 'Player'.
    private Camera main;

    void Start ()
    {
        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myPlayer = GameObject.Find("_GM").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        main = Camera.main;
	}
	
	void FixedUpdate ()
    {
        // Aguardando as cortinas abrirem.
        if (myPlayer.bGameStarted)
        {
            MoveForward();
        }

        // Setando o pulo para o valor atual do pulo, que varia caso o personagem seja a mulher, samurai ou ninja.
        jumpSpeed = myPlayer.playerStats.JumpPower; 

        if (bNoChao)
        {
            jmpCounter = 0;
            myRb.gravityScale = 1f;
            isGoingDown = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.tapCount == 1)
            {
                Jump();
            }
        }

        // Debugging
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
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
        jmpCounter++;

        if (jmpCounter < 2)
        {
            anim.SetBool("Jump", true);
            //Debug.Log("Pulando com força de " + jumpSpeed / 1.5f + "f! Restam " + jmpCounter + " pulos.");
            myRb.velocity = new Vector2(myRb.velocity.x, jumpSpeed / 1.5f);
        }
    }

    public void GoDown()
    {
        myRb.gravityScale = 10f;
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        bNoChao = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        main.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
