using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLevelScript : MonoBehaviour
{
    int randomBroken;
    public int roundNum = 0;
    public bool activateMe;
    public GameObject myobject;
    private GameObject[] gameObjects;
   // private int numberOfGameObjects = 7;

    public int randomGenerate()
    {
        int randNum = Random.Range(0, 6);
        return randNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (gameObjects == null)
        gameObjects = GameObject.FindGameObjectsWithTag("Arrow");

        if (gameObjects.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Arrow'");
        }

        //Show the general overview in the UI (Need to build this)   
            if (PlayerPrefs.GetInt("roundResults") == 1)
            {
                print("You won. Good work. But there's more to fix.");
                PlayerPrefs.SetInt("roundResults", 0);
                roundNum++;

                //Any UI celebratory stuff goes here
            }
            else if (PlayerPrefs.GetInt("roundResults") == 2)
            {
                print("You lost. But at least the rocket is still moving.");
                PlayerPrefs.SetInt("roundResults", 0);
            
                //Any UI loss stuff goes here
            }

            print(gameObjects.Length);

            randomBroken = randomGenerate();
            print(randomBroken);

            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }

            gameObjects[randomBroken].SetActive(true);

            if (randomBroken == 0)
            {
                //Comms Array
                print("Comms Array is broken.");
            }
            else if (randomBroken == 1)
            {
                //AntiGrav
                print("AntiGrav is broken.");
            }
            else if (randomBroken == 2)
            {
                //Thrusters
                print("Thrusters is broken.");
            }
            else if (randomBroken == 3)
            {
                //Life Support
                print("Life Support is broken.");
            }
            else if (randomBroken == 4)
            {
                //Landing Gear
                print("Landing Gear is broken.");
            }
            else if (randomBroken == 5)
            {
                //Heat Shield
                print("Heat Shield is broken.");
            }
            else if (randomBroken == 6)
            {
                //Batteries
                print("Batteries are broken.");
            }
            else
            {
                Debug.Log("random number generating be broken.");
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
