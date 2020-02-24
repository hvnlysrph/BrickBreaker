using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{

    float paddleSpeed = 1f;


    private Vector3 playerPos;

    private void Start()
    {
        transform.position = new Vector3(0, -4.5f, 0);
    }

    void Update()
    {
        //moves the paddle left and right
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);

        //Mathf allows us to limit the number we want to contain the movement in by setting the range
        playerPos = new Vector3(Mathf.Clamp(xPos, -6.47f, 6.47f), -4.5f, 0f);
        transform.position = playerPos;

    }

    //angles the ball based on where it hits on the paddle
    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == GetComponent<Collider>())
            {
                //This is the paddle's contact point
                float ballAngle = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody>().AddForce(450 * ballAngle, 0, 0);
            }
        }
    }
}
