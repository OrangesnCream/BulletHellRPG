using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;
    private Rigidbody2D rigidbody;

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
            rigidbody.constraints = RigidbodyConstraints2D.None;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            agent.acceleration = agent.speed;
            agent.SetDestination(goal.position);
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            agent.SetDestination(this.transform.position);
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }

    public void setMoveSpeed(float speed) { this.agent.speed = speed; }

    public float getMoveSpeed() { return this.agent.speed; }
}
