using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 1f;
    
    Vector3 playerPos = new Vector3 (0, -9.5f, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime);

        playerPos = new Vector3(Mathf.Clamp(xPos, -8, 8), -9.5f, 0);
        transform.position = playerPos;
    }
}
