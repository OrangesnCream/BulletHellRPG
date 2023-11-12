using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Command : MonoBehaviour
{
    private Barrel_pattern pattern;

    public float desired_speed;

    private bool nullNeeded;
    // Start is called before the first frame update
    void Start()
    {
        pattern = GetComponent<Barrel_pattern>();

        pattern.setSpeed(desired_speed);
        
        nullNeeded = true;
    }

    //----------action nullifier---------------------

    public void actionNull()
    {
        pattern.setCanShoot(false);
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
            actionNull();
        pattern.setCanShoot(true);
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
