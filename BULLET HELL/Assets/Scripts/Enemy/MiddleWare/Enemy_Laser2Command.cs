using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Laser2Command : MonoBehaviour
{
    private Enemy_LaserPattern pattern;
    private LaserMaker laser;
    private Enemy_AttackPattern attackPattern;

    public float desired_width;
    public float desired_chargewidth;
    public float desired_spinspeed;

    private bool nullNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        pattern = this.GetComponent<Enemy_LaserPattern>();
        laser = this.GetComponent<LaserMaker>();

        pattern.setWidth(desired_width);
        laser.setSpinSpeed(desired_spinspeed);
    }

    //--------------------reset functions-----------------------

    public void resetSpinSpeed()
    {
        laser.setSpinSpeed(0);
    }

    //----------action nullifier---------------------

    public void actionNull()
    {
        pattern.setCanShoot(false);
        resetSpinSpeed();
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        pattern.setCanShoot(true);
    }

    public void Spin()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        pattern.setCanShoot(true);
        laser.setSpinSpeed(desired_spinspeed);
    }

    public void SpinOpposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        pattern.setCanShoot(true);
        laser.setSpinSpeed(-1 * desired_spinspeed);
    }
    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
