using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform TopWall;
    public Transform BottomWall;
    public Transform LeftWall;
    public Transform RightWall;
    public int foodCount;

    // Start is called before the first frame update
    void Start()
    {
        //Repeat Spawn every 4 seconds, starting 3 seconds in
        //InvokeRepeating("Spawn", 1, foodCount);

        for (int i = 0; i < foodCount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int x = (int)Random.Range(LeftWall.position.x, RightWall.position.x);
        int y = (int)Random.Range(BottomWall.position.y, TopWall.position.y);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
