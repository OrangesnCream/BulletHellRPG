using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moveCommand : MonoBehaviour
{
    private Enemy_Move move;
    //private Enemy_Nav move;
    private HealthBar healthBar;

    public float desired_MoveSpeed;
    public int desired_MoveOpportunityCheck;
    public int desired_MaxHealth;

    private float temp_MoveSpeed;
    private int temp_Health;


    public int dashMultiplier;
    private bool nullNeeded;
    // Start is called before the first frame update
    void Start()
    {
        move = this.gameObject.GetComponent<Enemy_Move>();
        //move = this.gameObject.GetComponent<Enemy_Nav>();
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();

        move.setMoveSpeed(desired_MoveSpeed);
        move.setMovementOpportunityCheck(desired_MoveOpportunityCheck);
        healthBar.setMaxHealth(desired_MaxHealth);
        healthBar.setHealth(desired_MaxHealth);

        temp_MoveSpeed = move.getMoveSpeed();
        temp_Health = healthBar.getHealth();


        nullNeeded = true;
    }

    //--------------------reset functions-----------------------

    public void resetMoveSpeed() { move.setMoveSpeed(temp_MoveSpeed); }

    public void resetMaxHealth() { healthBar.setMaxHealth(desired_MaxHealth); }

    public void resetHealth() { healthBar.setHealth(temp_Health); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        resetMoveSpeed();
        move.setCanMove(false);
    }

    //----------------------actions-----------------------

    public void Dash()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        move.setMoveSpeed(this.dashMultiplier * this.desired_MoveSpeed);
        move.setCanMove(true);
    }

    public void Movement()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        move.setCanMove(true);
    }

    public void doNothing()
    {
        //nothing happens
    }
}
