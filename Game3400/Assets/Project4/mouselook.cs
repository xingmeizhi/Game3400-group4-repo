using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerBody;
    public float mouseSense = 100;
    float pitch = 0;

    void Start()
    {
        playerBody = transform.parent.transform;
        
        //hids cursor to center of screen. Breaks on esc
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        //Yaw
        playerBody.Rotate(Vector3.up * moveX);

        //Pitch
        pitch -= moveY;
        //all the way up or down
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
