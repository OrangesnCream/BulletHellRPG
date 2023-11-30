using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moveCommand : MonoBehaviour
{
    private Enemy_Nav move;

    public float desired_MoveSpeed;
    public float desired_StoppingDistance;

    public int dashMultiplier;
    private bool nullNeeded;
    // Start is called before the first frame update
    void Start()
    {
        move = this.gameObject.GetComponent<Enemy_Nav>();
        move.setStoppingDistance(desired_StoppingDistance);
        move.setMoveSpeed(desired_MoveSpeed);

        nullNeeded = true;
    }

    //--------------------reset functions-----------------------

    public void resetMoveSpeed() { move.setMoveSpeed(desired_MoveSpeed); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        resetMoveSpeed();
        move.setCanMove(false);
    }

    //----------------------actions-----------------------

    public void Dash()// make more options later cuz 2 is so fucking boring
    {
        if (nullNeeded)
            actionNull();
        move.setMoveSpeed(this.dashMultiplier * this.desired_MoveSpeed);
        move.setCanMove(true);
    }

    public void Movement()
    {
        if (nullNeeded)
            actionNull();
        move.setCanMove(true);
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
