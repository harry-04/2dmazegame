using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdinMove : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveSpeed = 1f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 2);
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        
    }
}
