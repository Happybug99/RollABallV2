using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoController : MonoBehaviour
{
    //player 2 variables
    private Rigidbody rb2;

    public float speed2;

    public float resetHeight2;

    public Vector3 startLocation2; 

    public float distToGround2 =  0.5f; //not needed? 

    void Start ()
    {
      

      rb2 = GetComponent<Rigidbody>();

      startLocation2 = transform.position;
    }

    void FixedUpdate ()
    {
     

      if (isGrounded()) {
        if (Input.GetKey(KeyCode.RightAlt)) {
         rb2.AddForce(0, 1000, 0);
        }
      }
      
      if (transform.position.y < resetHeight2) {
        transform.position = startLocation2;
        rb2.velocity = new Vector3(0, 10, 0);
      }

      //player 2 horizontal and vertical input
      float moveHorizontalP2 = Input.GetAxis("Horizontal2");
      float moveVerticalP2 = Input.GetAxis("Vertical2");
      
      Vector3 movement2 = new Vector3 (moveHorizontalP2, 0.0f, moveVerticalP2);

      rb2.AddForce (movement2 * speed2);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pick Up")) {
        other.gameObject.SetActive (false);
      }
    }
    bool isGrounded() {
      return Physics.Raycast(transform.position, Vector3.down, distToGround2);
    }
}
   