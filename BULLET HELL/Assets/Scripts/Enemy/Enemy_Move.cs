using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float opportunitycheck;

    private Vector2 direction;
    private GameObject player;
    private float movementopportunity;

    public Rigidbody2D rb;

    private void Awake()
    {
        movementopportunity = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        movementopportunity++;

        if (movementopportunity >= opportunitycheck)
        {
            direction.x = player.transform.position.x - this.gameObject.transform.position.x;
            direction.y = player.transform.position.y - this.gameObject.transform.position.y;

            rb.velocity = direction.normalized * speed;
            movementopportunity = 0;
        }
    }
}
