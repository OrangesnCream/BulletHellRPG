using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private float speed;
    private float opportunitycheck;
    private Vector2 direction;
    private GameObject player;
    private float movementopportunity;
    private bool canmove;

    public Rigidbody2D rb;

    private void Awake()
    {
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

    public void setMoveSpeed(float speed) { this.speed = speed; }

    public void setMovementOpportunityCheck(float movementopportunity) { this.opportunitycheck = movementopportunity; }

    public float getMoveSpeed() { return this.speed;}
}
