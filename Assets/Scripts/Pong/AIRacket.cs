using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    public Transform ball;
    public int speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.position.y > transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        else if (ball.position.y < transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }
    }
}
