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

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject brickParticles;
    [SerializeField] int brickValue = 10;
    [SerializeField] int durability = 1;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //get gamemanager object
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnCollisionEnter(Collision other)
    {
        //when hit, decrease the bricks durability
        durability--;

        //when durability hits 0, play particle effect, send score value to gameManager and destroy brick
        if (durability < 1)
        {
            Instantiate(brickParticles, transform.position, Quaternion.identity);
            gameManager.GetComponent<GameManager>().DestroyBrick(brickValue);
            Destroy(gameObject);
        }

    }
}
