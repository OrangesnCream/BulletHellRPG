using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Enemy_LaserAimCommand : MonoBehaviour
{
    private Enemy_LaserPattern pattern;
    private LaserMaker laser;
    private GameObject player;
    public GameObject enemy;

    public float desired_width;
    public float desired_chargewidth;
    public float desired_spinspeed;

    private float opportunity;
    public int opportunitycheck;

    private bool nullNeeded;
    private bool isShooting;
    private bool canRotate;
    private bool canSwingClock;
    private bool canSwingCounter;

    private Vector2 direction;
    private float angle;
    private float tempAngle;
   
    void Start()
    {
        pattern = this.GetComponent<Enemy_LaserPattern>();
        laser = this.GetComponent<LaserMaker>();
        player = GameObject.FindGameObjectWithTag("Player");

        pattern.setWidth(desired_width);
        laser.setSpinSpeed(desired_spinspeed);

        nullNeeded = true;
        isShooting = false;
        canRotate = false;
        canSwingClock = false;
        canSwingCounter = false;
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            this.opportunity++;
        }
    }

    void Update()
    {
        if (canRotate)
        {
            direction.x = player.transform.position.x - enemy.transform.position.x;
            direction.y = player.transform.position.y - enemy.transform.position.y;
            this.angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);

            if (canSwingClock)
                this.angle += laser.getDegrees() / 2;

            else if (canSwingCounter)
                this.angle -= laser.getDegrees() / 2;

            tempAngle = angle;
        }

        if (isShooting)
        {
            if (opportunity < opportunitycheck / 4)
            {
                pattern.setCanHit(false);
                pattern.setWidth(desired_chargewidth);
            }
            else if (opportunity < opportunitycheck / 2 && opportunity > opportunity / 4)
            {
                canRotate = false;
            }
            else if (opportunity > opportunitycheck / 2)
            {
                pattern.setCanHit(true);
                pattern.setWidth(desired_width);

                if (canSwingClock)
                    this.angle = Mathf.Lerp(tempAngle, tempAngle - laser.getDegrees(), (opportunity - opportunitycheck / 2) / (opportunitycheck - opportunitycheck / 2));
                if (canSwingCounter)
                    this.angle = Mathf.Lerp(tempAngle, tempAngle + laser.getDegrees(), (opportunity - opportunitycheck / 2) / (opportunitycheck - opportunitycheck / 2));
            }
        }
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, this.angle);
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
        canRotate = false;
        canSwingClock = false;
        canSwingCounter = false;
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
            actionNull();
        canRotate = true;
        isShooting = true;
        pattern.setCanShoot(true);
    }

    public void SwingClock()
    {
        if (nullNeeded)
            actionNull();
        canRotate = true;
        canSwingClock = true;
        isShooting = true;
        pattern.setCanShoot(true);
        isShooting = true;
    }

    public void SwingCounter()
    {
        if (nullNeeded)
            actionNull();
        canRotate = true;
        canSwingCounter = true;
        isShooting = true;
        pattern.setCanShoot(true);
    }
    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
