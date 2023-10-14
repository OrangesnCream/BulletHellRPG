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
    public bool canmove;

    public Rigidbody2D rb;

    private void Awake()
    {
        movementopportunity = opportunitycheck;
        player = GameObject.FindGameObjectWithTag("Player");
        canmove = true;
    }

    private void FixedUpdate()
    {
        movementopportunity++;

        if (movementopportunity >= opportunitycheck && canmove)
        {
            direction.x = player.transform.position.x - this.gameObject.transform.position.x;
            direction.y = player.transform.position.y - this.gameObject.transform.position.y;

            rb.velocity = direction.normalized * speed;
            movementopportunity = 0f;
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }
}
