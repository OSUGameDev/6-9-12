using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    public float pointsNeeded = 3;
    public Vector2 maxSpeed;

    int playerPoints = 0;
    int botPoints = 0;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        maxSpeed.x = speed;
        maxSpeed.y = speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.name == "RightWall")
        {
            playerPoints++;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

        if (col.gameObject.name == "LeftWall")
        {
            botPoints++;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.x > speed || GetComponent<Rigidbody2D>().velocity.y > speed)
        {
            GetComponent<Rigidbody2D>().velocity = maxSpeed;
        }

        if(playerPoints == pointsNeeded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            print("You win!");
            PlayerPrefs.SetInt("roundResults", 1);
            SceneManager.LoadScene(1);
        }

        if(botPoints == pointsNeeded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            print("You lose!");
            PlayerPrefs.SetInt("roundResults", 2);
            SceneManager.LoadScene(1);
        }
    }
}
