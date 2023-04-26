using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float difficultyMultiplier = 1.3f;

    public float minXSpeed = 0.8f;
    public float maxXSpeed = 1.2f;
    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.velocity = new Vector2(Random.Range(minXSpeed,maxYSpeed) * (Random.value > 0.5f ? -1 :1 ), Random.Range(minYSpeed,maxYSpeed) * (Random.value > 0.5f ? -1 : 1));
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
            // play the sound
            audioSource.Play();
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
            // play the sound
            audioSource.Play();
            // collided with the right paddle
            if (collision.transform.position.x > transform.position.x && rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(-rb.velocity.x * difficultyMultiplier, rb.velocity.y * difficultyMultiplier);
            }
            // collided with the left paddle
            if (collision.transform.position.x < transform.position.x && rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(-rb.velocity.x * difficultyMultiplier, rb.velocity.y * difficultyMultiplier);
            }
        }
    }
}
