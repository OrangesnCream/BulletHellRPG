using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;
    private new Rigidbody2D rigidbody;

    private bool canmove;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        goal = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canmove)
        {
            rigidbody.isKinematic = false;
            agent.acceleration = agent.speed;
            agent.SetDestination(goal.position);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.isKinematic = true;
            agent.SetDestination(this.transform.position);
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }

    public void setMoveSpeed(float speed) { this.agent.speed = speed; }

    public void setStoppingDistance(float distance) { this.agent.stoppingDistance = distance; }

    public float getMoveSpeed() { return this.agent.speed; }

    public Vector2 getMoveVelocity() { return this.agent.velocity; }
}
