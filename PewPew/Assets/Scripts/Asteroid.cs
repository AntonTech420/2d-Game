using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.5f;
    public float Minsize = 0.5f;
    public float Maxsize = 10.0f;
    public float AsteroidSpeed = 20.0f;
    public float MaxLifetime = 60.0f;
 
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    
    private BoxCollider2D boxCollider;
    

    private void Awake() 
    {
       _spriteRenderer =GetComponent<SpriteRenderer>(); 
       _rigidbody = GetComponent<Rigidbody2D>();
       boxCollider = GetComponent <BoxCollider2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer.sprite =  sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size * 2.0f;
    }
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.AsteroidSpeed);
        Destroy(this.gameObject, this.MaxLifetime);//Asteroid life span before despawning
    }

    private void OnTriggerEnter2D()
        {
            if ((this.size * 0.05f) >= this.Minsize)
            {
                createSplit();
                createSplit();  
            }
            Destroy(this.gameObject);
        }
    

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Bullet")
    //     {
    //         if ((this.size * 0.05f) >= this.Minsize)
    //         {
    //             createSplit();
    //             createSplit();  
    //         }
    //         Destroy(this.gameObject);
    //     }

    // }

    private void createSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.05f;

        Asteroid half = Instantiate(this, transform.position, this.transform.rotation);
        half.size = this.size * 0.05f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.AsteroidSpeed);
    }

   
}
