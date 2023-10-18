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
        canmove = false;
        movementopportunity = opportunitycheck;
    }

    private void FixedUpdate()
    {
        movementopportunity++;

        if (movementopportunity >= opportunitycheck && canmove)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            direction.x = player.transform.position.x - this.gameObject.transform.position.x;
            direction.y = player.transform.position.y - this.gameObject.transform.position.y;

            rb.velocity = direction.normalized * speed;
            movementopportunity = 0f;
        }
        else if (!canmove)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }

    public void setMoveSpeed(float speed) { this.speed = speed; }

    public void setMovementOpportunityCheck(float movementopportunity) { this.opportunitycheck = movementopportunity; }

    public float getMoveSpeed() { return this.speed;}
}
