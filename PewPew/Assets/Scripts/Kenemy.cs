using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deatheffect;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <=0)
        {
            Die();
        }

    }
    void Die ()
    {
       
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
