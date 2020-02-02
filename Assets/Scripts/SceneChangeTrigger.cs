using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChangeTrigger : MonoBehaviour
{

    public Animator animator;

    [SerializeField]
    private int newScene;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("FadeOut");
            SceneManager.LoadScene(newScene);
        }
    }
}
