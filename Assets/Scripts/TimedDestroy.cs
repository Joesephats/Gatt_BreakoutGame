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

//component for particle effects
//destroys particle effects after 1 second

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] float destroyTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
