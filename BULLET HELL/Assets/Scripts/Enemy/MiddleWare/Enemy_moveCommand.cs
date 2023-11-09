using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moveCommand : MonoBehaviour
{
    private Enemy_Nav move;
    private HealthBar healthBar;

    public float desired_MoveSpeed;
    public int desired_MaxHealth;

    public int dashMultiplier;
    private bool nullNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        move = this.gameObject.GetComponent<Enemy_Nav>();
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();

        healthBar.setMaxHealth(desired_MaxHealth);
        healthBar.setHealth(desired_MaxHealth);
        move.setMoveSpeed(desired_MoveSpeed);

        nullNeeded = true;
    }

    //--------------------reset functions-----------------------

    public void resetMoveSpeed() { move.setMoveSpeed(desired_MoveSpeed); }

    public void resetMaxHealth() { healthBar.setMaxHealth(desired_MaxHealth); }

    public void resetHealth() { healthBar.setHealth(desired_MaxHealth); }

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
