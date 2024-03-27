using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float initialVelocity = 600f;
    Rigidbody ballRigidBody;
    bool ballInPlay;



    // Start is called before the first frame update
    void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            ballRigidBody.isKinematic = false;
            ballRigidBody.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
        }
    }
}
