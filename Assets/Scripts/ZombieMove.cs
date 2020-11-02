using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rigidbody2D;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int Walkdirection;

    public Collider2D walkzone;

    private bool hasWalkZone;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkzone != null)
        {
            minWalkPoint = walkzone.bounds.min;
            maxWalkPoint = walkzone.bounds.max;
            hasWalkZone = true;
        }
    }

    private void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;



            switch (Walkdirection)
            {
                case 0:
                    rigidbody2D.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    rigidbody2D.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    rigidbody2D.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    rigidbody2D.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }

        else
        {
            waitCounter -= Time.deltaTime;

            rigidbody2D.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        Walkdirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;

    }


}
