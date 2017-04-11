using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour {

    private Rigidbody2D myRb;
    public float shurikenSpeed = 10f;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        myRb.velocity = new Vector2(-1 * shurikenSpeed, myRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ShurikenDestroy"))
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == ("Inimigos"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
