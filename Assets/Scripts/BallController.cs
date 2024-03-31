//////////////////////////////////////////////
//Assignment/Lab/Project: BreakoutGame
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 03/30/2024
/////////////////////////////////////////////

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
        //launches the ball when left click.
        if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            ballRigidBody.isKinematic = false;
            ballRigidBody.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
        }
    }
}
