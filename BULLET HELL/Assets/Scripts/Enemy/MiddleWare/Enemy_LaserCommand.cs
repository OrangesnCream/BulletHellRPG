using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LaserCommand : MonoBehaviour
{
    private Enemy_LaserPattern pattern;
    private LaserMaker laser;

    public float desired_width;
    public float desired_chargewidth;
    public float desired_spinspeed;

    private float opportunity;
    public int opportunitycheck;

    private bool nullNeeded;
    private bool isShooting;
    
    void Start()
    {
        pattern = this.GetComponent<Enemy_LaserPattern>();
        laser = this.GetComponent<LaserMaker>();

        pattern.setWidth(desired_width);
        laser.setSpinSpeed(desired_spinspeed);

        nullNeeded = true;
        isShooting = false;
        opportunity = 0;
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            opportunity++;
        }
    }

    private void Update()
    {
        if (isShooting)
        {
            if (opportunity < opportunitycheck / 2)
            {
                pattern.setCanHit(false);
                pattern.setWidth(desired_chargewidth);
            }
            else if (opportunity > opportunitycheck / 2)
            {
                pattern.setCanHit(true);
                pattern.setWidth(desired_width);
            }
        }
    }

    //--------------------reset functions-----------------------

    public void resetSpinSpeed() { laser.setSpinSpeed(0); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        isShooting = false;
        opportunity = 0;
        pattern.setCanShoot(false);
        resetSpinSpeed();
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
            actionNull();
        pattern.setCanShoot(true);
        isShooting = true;
    }

    public void Spin()
    {
        if (nullNeeded)
            actionNull();
        pattern.setCanShoot(true);
        isShooting = true;
        laser.setSpinSpeed(desired_spinspeed);
    }

    public void SpinOpposite()
    {
        if (nullNeeded)
            actionNull();
        pattern.setCanShoot(true);
        isShooting = true;
        laser.setSpinSpeed(-1 * desired_spinspeed);
    }
    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}