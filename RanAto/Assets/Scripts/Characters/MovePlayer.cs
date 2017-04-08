using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private TutorialManager tutorialScript;
    private Camera main;

    public Text debugPulo;

    void Start ()
    {
        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myPlayer = GameObject.Find("_GM").GetComponent<GameManager>();
        tutorialScript = GameObject.Find("TutorialTrigger01").GetComponent<TutorialManager>();
        anim = GetComponent<Animator>();

        main = Camera.main;
	}
	
	void Update ()
    {
        // Setando o pulo para o valor atual do pulo, que varia caso o personagem seja a mulher, samurai ou ninja.
        jumpSpeed = myPlayer.playerStats.JumpPower;

        // Aguardando as cortinas abrirem.
        if (!GameManager.bPause)
        {
            if (myPlayer.bGameStarted)
            {
                MoveForward();
            }
        }

        // Resetando variáveis assim que o jogador pisa no chão.
        if (!GameManager.bPause)
        {
            if (bNoChao)
            {
                jmpCounter = 2;
                myRb.gravityScale = 1f;
                isGoingDown = false;
            }
        }

        // Controladores do touch
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && TutorialManager.tutorialExibido)
            {
                Jump();

                if (!TutorialManager.fezTutorialPulo)
                {
                    TutorialManager.fezTutorialPulo = true;
                    GameManager.bPause = false;
                    tutorialScript.FezTutorialPulo();
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
        }

        // Debugging p/ mouse
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        // Debugging p/ pulo duplo
        debugPulo.text = "Pulo duplo: " + jmpCounter;

        if (GameManager.bPause)
        {
            anim.enabled = false;
        }
        else
        {
            anim.enabled = true;
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
        jmpCounter--;

        if (jmpCounter > 0)
        {
            anim.SetBool("Jump", true);
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
