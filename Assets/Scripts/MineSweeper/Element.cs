using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Element : MonoBehaviour
{
    public bool mine;

    private bool change = false;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    // Start is called before the first frame update
    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Default_minesweep_tile";
    }

    void OnMouseUpAsButton()
    {
        if (mine)
        {
            Playfield.uncoverMines();

            print("you lose");
            PlayerPrefs.SetInt("roundResults", 2);
            SceneManager.LoadScene(1);

        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Playfield.adjacentMines(x, y));

            Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);

            if (Playfield.isFinished())
            {
                //Printing you win everytime the player doesn't lose. Fix that and jumping scenes will be fixed.
                print("You win");
                SceneManager.LoadScene(1);
                PlayerPrefs.SetInt("roundResults", 1);

            }
        }
    }
}
