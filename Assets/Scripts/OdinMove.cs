using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdinMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1f;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Gives a value between =1 and 1
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal == -1)
        {
            animator.SetBool("walk_left", true);
        }
        else
        {
            animator.SetBool("walk_left", false);
        }

        if(horizontal == 1)
        {
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("walk_right", true);
        }
        else
        {
            animator.SetBool("walk_right", false);
        }
      
        

        
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical !=0) // check for diagonal movement
        {
            //limit movement diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }



        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

}
