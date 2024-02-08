using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based off: https://github.com/jiankaiwang/FirstPersonController
public class PlayerCameraController : MonoBehaviour
{    
    /* 
    This Camera View will move with the mouse
    */

    [SerializeField] public float sensitivity = 5.0f;
    [SerializeField] public float smoothing = 2.0f;
    // the player is the capsule
    public GameObject player;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

	// Use this for initialization
	void Start () {
        //player = this.transform.parent.gameObject;
        // transform.Translate(transform.position.x, transform.parent.transform.position.y / 2, transform.position.z);;
	}
	
	// Update is called once per frame
	void Update () {
        // md is mouse delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        // incrementally add to the camera look
        mouseLook += smoothV;

        // clamp camera y between -90, 90
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        // keep camera x within reasonable limits
        while (mouseLook.x < 0f) { mouseLook.x += 360f; }
        while (mouseLook.x >= 360f) { mouseLook.x -= 360f; }

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}