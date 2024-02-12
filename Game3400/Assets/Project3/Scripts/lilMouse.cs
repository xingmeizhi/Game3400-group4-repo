using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilMouse : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float changeDirectionTime = 2.0f;
    private float timer;

    void Start()
    {
        ChangeDirection();
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0;
        }

        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }


    private void ChangeDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            ChangeDirection();
        }
    }
}
