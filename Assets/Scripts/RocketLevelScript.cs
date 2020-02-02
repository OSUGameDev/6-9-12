using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLevelScript : MonoBehaviour
{
    int randomBroken;
    public int roundNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Show the general overview in the UI (Need to build this)   
        if (roundNum < 5)
        {
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
