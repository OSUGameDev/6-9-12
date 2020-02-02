using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;
    public float speed = 0.3f;
    public int needToEat = 10;

    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    bool playing = true;
    int eaten = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", speed, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("You lose!");
            PlayerPrefs.SetInt("roundResults", 2);
            SceneManager.LoadScene(1);
        }
    }

    void Move()
    {
        if(playing)
        {
            Vector2 v = transform.position;

            transform.Translate(dir);

            if (ate)
            {
                GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
                tail.Insert(0, g.transform);
                ate = false;
            }
            else if (tail.Count > 0)
            {
                tail.Last().position = v;
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("Snake_Food"))
        {
            ate = true;
            Destroy(coll.gameObject);
            eaten++;

            if(needToEat == eaten)
            {
                playing = false;
                PlayerPrefs.SetInt("roundResults", 1);
                SceneManager.LoadScene(1);
                print("You win!");
            }
        }
        else if(coll.gameObject.tag == "Wall")
        {
            playing = false;
            print("You lose");
            PlayerPrefs.SetInt("roundResults", 2);
            SceneManager.LoadScene(1);
        }
    }
}
