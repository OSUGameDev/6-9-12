using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float speed = 2;
    public float force = 300;
    public float maxTime = 10;
    public Rigidbody2D rb;

    float countDown;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        countDown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);

        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            Debug.Log("You win!");
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            PlayerPrefs.SetInt("roundResults", 1);
            SceneManager.LoadScene(1);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("You lose");
        PlayerPrefs.SetInt("roundResults", 2);
        SceneManager.LoadScene(1);
    }
}
