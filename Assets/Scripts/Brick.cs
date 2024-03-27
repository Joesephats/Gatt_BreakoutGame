using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject brickParticles;
    [SerializeField] int brickValue = 10;
    [SerializeField] int durability = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        durability--;

        if (durability < 1)
        {
            Instantiate(brickParticles, transform.position, Quaternion.identity);
            GameManager.Instance.DestroyBrick(brickValue);
            Destroy(gameObject);
        }

    }
}
