using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIctoryScreen : MonoBehaviour
{
    public int DeadEnemies;
    public int Amount;

   
    void Start()
    {
        int Amount = GameObject.Find("Zombie (3)").GetComponent<Enemy>().EnemiesKilled;
        Debug.Log(Amount);
    }

    
    void Update()
    {
        if(Amount > 0)
        {
            DeadEnemies +=1;
            Debug.Log(DeadEnemies);
            Debug.Log(Amount);
        }

        
        
        

    }
}
