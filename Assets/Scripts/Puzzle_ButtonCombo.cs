﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_ButtonCombo : MonoBehaviour
{
    public float maxTime = 100;
    public int lettersNeeded = 4;

    int lettersCorrect = 0;
    float countDown;
    bool playing = true;
    bool winner = false;
    bool loser = false;
    char[] generated = new char[4];

    // Start is called before the first frame update
    void Start()
    {
        countDown = maxTime;
        letterGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                playing = false;
                loser = true;
            }
        }

        if (winner == true)
            print("Winner!");

        if (loser == true)
            print("Loser!");
    }

    void letterGenerator()
    {
        for (int i = 0; i < lettersNeeded; i++)
        {
            generated[i] = (char)('a' + Random.Range(0, 26));
            print(generated[i]);
        }
    }

    void OnGUI()
    {
        if(lettersCorrect < lettersNeeded)
        {
            //We will need to show the letters in the UI somehow.
            Event e = Event.current;
            if (e.isKey)
            {
                print(e.character);
                if (e.character == generated[lettersCorrect])
                {
                    print("Correct!");
                    lettersCorrect++;
                }
                /*
                else if (e.character != " ")
                {
                    print("Incorrect.");
                    lettersCorrect = lettersNeeded;
                    loser = true;
                }
                */
            }
        }
        else
        {
            winner = true;
        }
    }
}
