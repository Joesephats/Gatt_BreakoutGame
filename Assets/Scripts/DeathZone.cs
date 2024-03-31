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

public class DeathZone : MonoBehaviour
{
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //get GameManager Object
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the ball collides with the deathzone, call LoseLife on GameManager
        gameManager.GetComponent<GameManager>().LoseLife();
    }
}
