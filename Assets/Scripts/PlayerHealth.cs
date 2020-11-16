using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    
    

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
            GetComponent<OdinMove>().enabled = false;
            GetComponent<PlayerCombat>().enabled = false;
            SceneManager.LoadScene("OdinsWrath");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.gameObject.tag == ("ZombieTag"))
        {
            TakeDamage(1);
        }

        if (col.gameObject.tag == ("HealthPotion"))
        {
            currentHealth += 1;

            healthBar.SetHealth(currentHealth);

            Destroy(GameObject.Find("HealthPotion"));
        }

        if (col.gameObject.tag == ("HealthPotion2"))
        {
            currentHealth += 1;

            healthBar.SetHealth(currentHealth);

            Destroy(GameObject.Find("HealthPotion (1)"));
        }

        if (col.gameObject.tag == ("HealthPotion3"))
        {
            currentHealth += 1;

            healthBar.SetHealth(currentHealth);

            Destroy(GameObject.Find("HealthPotion (2)"));
        }
    }

    // OnCollisionEnter2d(Collision2d collision)

}
