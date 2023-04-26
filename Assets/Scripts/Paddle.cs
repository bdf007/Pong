using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float speed;
    public int playerNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical" + playerNumber);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalMovement) * speed;
    }
}
