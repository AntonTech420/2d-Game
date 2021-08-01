using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lives : MonoBehaviour
{

    public float health = 3.0f;

    private void OnTriggerEnter2D()
    {
        health--;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            die();
        }


    }
    void die()
    {
        Destroy(gameObject);    
    }
}
