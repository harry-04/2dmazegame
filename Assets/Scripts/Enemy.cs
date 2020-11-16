using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 2;
    int currentHealth;

    public int EnemiesKilled;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();       
        }
    }

    void Die()
    {
        GetComponent<ZombieMove>().enabled = false;
        Debug.Log("Enemy Died!");
        //Die animation
        animator.SetBool("IsDead", true);

        //disable rigidbody collision
        GetComponent<Collider2D>().enabled = false;


        //Disable the enemy
        this.enabled = false;

        EnemiesKilled += 1; 



    }

       

   
}
