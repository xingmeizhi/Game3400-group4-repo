using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKing : MonoBehaviour
{

    public float speed = 1f;
    public GameObject player;
    Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;
        transform.Rotate(0, 90, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
}
