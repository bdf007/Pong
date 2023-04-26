using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 1.0f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-0.5f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collided with the limit
        if(collision.tag == "Limit")
        {
            // collided with the top limit
            if(collision.transform.position.y > transform.position.y && rb.velocity.y>0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }

            // collided with the bottom limit
            if (collision.transform.position.y < transform.position.y && rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
        }
        // collided with the paddle
        else if (collision.tag == "Paddle")
        {
            // collided with the right paddle
            if (collision.transform.position.x > transform.position.x && rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
            // collided with the left paddle
            if (collision.transform.position.x < transform.position.x && rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
        }
    }
}
