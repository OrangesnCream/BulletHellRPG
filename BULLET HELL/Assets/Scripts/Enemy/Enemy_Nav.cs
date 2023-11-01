using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;

    private bool canmove;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        goal = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canmove)
        {
            agent.acceleration = agent.speed;
            agent.SetDestination(goal.position);
        }
        else
        {
            agent.SetDestination(this.transform.position);
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }

    public void setMoveSpeed(float speed) { this.agent.speed = speed; }

    public float getMoveSpeed() { return this.agent.speed; }
}
