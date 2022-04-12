using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    public float resetHeight;

    public Vector3 startLocation; 

    public float distToGround =  0.5f;

    
    void Start ()
    {
      rb = GetComponent<Rigidbody>();

      startLocation = transform.position;

      
    }

    void FixedUpdate ()
    {
      if (isGrounded()) {
        if (Input.GetKey(KeyCode.Space)) {
         rb.AddForce(0, 1000, 0);
        }
      }

      
      if (transform.position.y < resetHeight) {
        transform.position = startLocation;
        rb.velocity = new Vector3(0, 10, 0);
      }

      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
     
      
      Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
     

      rb.AddForce (movement * speed);
     
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pick Up")) {
        other.gameObject.SetActive (false);
      }
    }
    bool isGrounded() {
      return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
   