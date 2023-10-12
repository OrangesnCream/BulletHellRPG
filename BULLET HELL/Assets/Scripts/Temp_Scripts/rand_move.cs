using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float opportunitycheck;

    private float movementopportunity;
    private Vector2 direction;

    private void Start()
    {
        movementopportunity = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementopportunity++;

        if (movementopportunity >= opportunitycheck)
        {
            direction.x = Random.Range(-1.0f, 1.0f);
            direction.y = Random.Range(-1.0f, 1.0f);

            rb.velocity = direction * speed;
            movementopportunity = 0;
        }
    }
}
