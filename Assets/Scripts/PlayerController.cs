using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public bool spinner = false;

    Vector2 movement;

    void Update()
    {
        //spinner
        if(spinner == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.rotation = 0f;
        }

        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
