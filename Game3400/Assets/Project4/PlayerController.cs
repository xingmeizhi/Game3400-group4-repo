using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;
    Vector3 input,moveDirection;
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    public float airControl = 10;
    public float gravity = 9.8f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward*moveVertical).normalized;
        input *= moveSpeed;
        if (controller.isGrounded)
        {
            moveDirection = input;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection,input,airControl*Time.deltaTime);
        }
        moveDirection.y -= gravity*Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);    
    }
}
