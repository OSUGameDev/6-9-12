using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLevelScript : MonoBehaviour
{
    int randomBroken;
    public int roundNum = 0;
    public bool activateMe;
    public GameObject myobject;

    // Start is called before the first frame update
    void Start()
    {
        //arrows[0] = FindingObjectOfName


        //Show the general overview in the UI (Need to build this)   
        if (roundNum < 5)
        {
            if (PlayerPrefs.GetInt("roundResults") == 1)
            {
                print("You won. Good work. But there's more to fix.");
                PlayerPrefs.SetInt("roundResults", 0);

                //Any UI celebratory stuff goes here
            }
            else if (PlayerPrefs.GetInt("roundResults") == 2)
            {
                print("You lost. But at least the rocket is still moving.");
                PlayerPrefs.SetInt("roundResults", 0);
            
                //Any UI loss stuff goes here
            }

            randomBroken = Random.Range(0, 6);
            print(randomBroken);
            if (randomBroken == 0)
            {
                //Comms Array
                

            }
            else if (randomBroken == 1)
            {
                //AntiGrav

            }
            else if (randomBroken == 2)
            {
                //Thrusters

            }
            else if (randomBroken == 3)
            {
                //Life Support

            }
            else if (randomBroken == 4)
            {
                //Landing Gear

            }
            else if (randomBroken == 5)
            {
                //Heat Shield

            }
            else if (randomBroken == 6)
            {
                //Batteries

            }
            else
            {
                Debug.Log("random number generating be broken.");
            }
        }
        else
        {
            //Ending sequence

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
