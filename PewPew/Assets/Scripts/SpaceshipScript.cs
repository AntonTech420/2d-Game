using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    //public float speed = 20;
    public float maxSpeed=3.8f;
    public float rotSpeed=180f;
    private Rigidbody2D rb2d;
    
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D> ();        
    }

    
    //void FixedUpdate() 
   //{
       //float moveHorizontal = Input.GetAxis("Horizontal");
       //float moveVertical = Input.GetAxis("Vertical");
       //Vector3 movement = new Vector3(moveHorizontal, moveVertical);  
       //rb2d.AddForce(movement*speed);
   //}
   void FixedUpdate()
    {


        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler( 0, 0, z);
        transform.rotation = rot;
 
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;
        transform.position = pos;
}
}
