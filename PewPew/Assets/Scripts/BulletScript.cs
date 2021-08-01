using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed =500f;
    public int damage = 25;
    private Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject collision;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(this.gameObject);
    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void project(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
        
    }

    


    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    
// private void OnTriggerEnter2D(Collider2D collision)
//     {
//         Asteroid enemy = collision.GetComponent<Asteroid>();
        
//         Destroy(gameObject);

//     }
        void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }


    
}
