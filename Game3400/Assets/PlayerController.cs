
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlayerController : MonoBehaviour
{
    /* 
    Create a variable called 'rb' that will represent the 
    rigid body of this object.
    */
    public GameObject ratKing;
    Vector3 ratPosition;
    private Rigidbody rb;
    public float moveSpeed = 0;
    /* 
    Creates a public variable that will be used to set 
    the movement intensity (from within Unity)
    */

    void Start()
    {
    	// make our rb variable equal the rigid body component
        rb = GetComponent<Rigidbody>();
        ratPosition = ratKing.transform.position;
        moveSpeed = 0;
        // yPos = transform.position.y;
    }
 
    void Update()
    {
        ratPosition = ratKing.transform.position;
        if (Vector3.Distance(ratPosition, transform.position) < 3) {
            moveSpeed = 2;
        }
        // Move Forwards
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        // Move Backwards
        else if (Input.GetKey(KeyCode.S))
        {   
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        // Move Left
        else if (Input.GetKey(KeyCode.A))
        {
           transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        // Move Right
        else if (Input.GetKey(KeyCode.D))
        {
           transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}