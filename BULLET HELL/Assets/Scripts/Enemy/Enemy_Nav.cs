using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;

    private float speed;
    private bool canmove;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindWithTag("Player").transform;
        agent.destination = goal.position;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            agent.SetDestination(goal.position);
        }
    }

    public void setCanMove(bool canmove) { this.canmove = canmove; }

    public void setMoveSpeed(float speed) { this.agent.speed = speed; }

    public float getMoveSpeed() { return this.agent.speed; }
}
