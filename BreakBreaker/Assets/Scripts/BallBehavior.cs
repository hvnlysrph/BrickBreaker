using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float initialVelocity = 450f;

    public GameManager manager;

    Rigidbody rb;
    bool ballInPlay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            manager.inPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
