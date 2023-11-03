using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Enemy_LaserAimCommand : MonoBehaviour
{
    private Enemy_LaserPattern pattern;
    private LaserMaker laser;
    private Enemy_AttackPattern attackPattern;
    private GameObject player;
    public GameObject enemy;

    public float desired_width;
    public float desired_chargewidth;
    public float desired_spinspeed;

    private bool nullNeeded;
    private Vector2 direction;
    private float angle;
    // Start is called before the first frame update
    void Awake()
    {
        pattern = this.GetComponent<Enemy_LaserPattern>();
        laser = this.GetComponent<LaserMaker>();
        player = GameObject.FindGameObjectWithTag("Player");

        pattern.setWidth(desired_width);
        laser.setSpinSpeed(desired_spinspeed);
    }

    void Update()
    {
        direction.x = player.transform.position.x - enemy.transform.position.x;
        direction.y = player.transform.position.y - enemy.transform.position.y;
        angle = (Mathf.Atan2(direction.y, direction.x) * 180) / Mathf.PI;

        if (laser.getColumns() > 1)
        {
            angle += laser.getDegrees() / 4;
        }

        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
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
