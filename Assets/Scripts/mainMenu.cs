using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{

    public void playGame ()
    {
        //Put our main gameplay scene will go after this within our build.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame ()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

}
