using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_ButtonMashing : MonoBehaviour
{
    public int pressesNeeded = 10;
    public float maxTime = 5;
    public TextMesh scoreLabel;
    public TextMesh textLabel;

    int pressedCount = 0;
    float countDown;
    bool playing = true;
    bool winner = false;
    bool loser = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing == true)
        {
            if(countDown > 0)
            {
                countDown -= Time.deltaTime;
                textLabel.text = "Time Left: " + countDown.ToString("f1");
            }
            else
            {
                playing = false;
                loser = true;
            }

            if(pressedCount < pressesNeeded)
            {
                if (Input.GetKeyDown("space"))
                {
                    pressedCount++;
                    scoreLabel.text = "Score: " + pressedCount;
                }
            }
            else
            {
                playing = false;
                winner = true;
            }
        }

        if (winner == true)
            print("Winner!");

        if (loser == true)
            print("Loser!");
    }
}
