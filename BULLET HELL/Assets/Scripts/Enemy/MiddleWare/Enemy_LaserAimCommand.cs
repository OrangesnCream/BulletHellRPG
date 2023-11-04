using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Enemy_LaserAimCommand : MonoBehaviour
{
    private Enemy_LaserPattern pattern;
    private LaserMaker laser;
    public Enemy_AttackPattern attackPattern;
    private GameObject player;
    public GameObject enemy;

    public float desired_width;
    public float desired_chargewidth;
    public float desired_spinspeed;

    private int opportunity;
    private int opportunitycheck;

    private bool nullNeeded;
    private bool isShooting;
    private bool canRotate;
    private Vector2 direction;
    private float angle;
    // Start is called before the first frame update
    void Awake()
    {
        pattern = this.GetComponent<Enemy_LaserPattern>();
        laser = this.GetComponent<LaserMaker>();
        player = GameObject.FindGameObjectWithTag("Player");
        opportunitycheck = attackPattern.getOpportunityCheck();

        pattern.setWidth(desired_width);
        laser.setSpinSpeed(desired_spinspeed);

        nullNeeded = true;
        isShooting = false;
        canRotate = true;
    }

    void FixedUpdate()
    {
        if (canRotate) 
        {
            direction.x = player.transform.position.x - enemy.transform.position.x;
            direction.y = player.transform.position.y - enemy.transform.position.y;
            angle = (Mathf.Atan2(direction.y, direction.x) * 180) / Mathf.PI;

            if (laser.getColumns() > 1)
            {
                angle += laser.getDegrees() / 4;
            }
        }
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (isShooting)
        {
            Debug.Log("opp: " + opportunity);
            opportunity++;
            if (opportunity < opportunitycheck / 2)
            {
                pattern.setCanHit(false);
                pattern.setWidth(desired_chargewidth);
            }
            else if (opportunity > opportunitycheck / 2)
            {
                canRotate = false;
                pattern.setCanHit(true);
                pattern.setWidth(desired_width);
            }
        }
    }

    //--------------------reset functions-----------------------

    public void resetSpinSpeed()
    {
        laser.setSpinSpeed(0);
    }

    //----------action nullifier---------------------

    public void actionNull()
    {
        isShooting = false;
        opportunity = 0;
        pattern.setCanShoot(false);
        resetSpinSpeed();
        canRotate = true;
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        pattern.setCanShoot(true);
        isShooting = true;
    }

    public void Spin()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        pattern.setCanShoot(true);
        isShooting = true;
        laser.setSpinSpeed(desired_spinspeed);
    }

    public void SpinOpposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
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
