using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Enemy_ShootingPattern[] shootingPattern;
    public BulletParticles[] particles;
    public Transform ShootPoint_Aim;
    private Enemy_Move move;
    //private Enemy_Nav nav;
    private HealthBar healthBar;
    private GameObject player;

    private int temp_FireRate;
    private float temp_BulletSpeed;
    private float temp_Size;
    private int temp_Bounce;
    private float temp_MoveSpeed;
    private int temp_Health;

    public int desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;
    public float desired_MoveSpeed;
    public int desired_MoveOpportunityCheck;
    public int desired_MaxHealth;

    public int dashMultiplier;
    private bool nullNeeded;
    private Vector2 vecPlayer;
    private Vector2 vecEnemy;
    private float angle;

    private void Start()
    {
        move = this.gameObject.GetComponent<Enemy_Move>();
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();
        //nav = this.gameObject.GetComponent<Enemy_Nav>();
        player = GameObject.FindGameObjectWithTag("Player");

        foreach(Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setFireRate(desired_FireRate);
            pattern.setBulletSpeed(desired_BulletSpeed);
            pattern.setSize(desired_Size);
            pattern.setBounce(desired_Bounce);
        }
        foreach(BulletParticles particles in particles)
        {
            particles.setSpinSpeed(desired_SpinSpeed);
        }
        move.setMoveSpeed(desired_MoveSpeed);
        //nav.setMoveSpeed(desired_MoveSpeed);
        move.setMovementOpportunityCheck(desired_MoveOpportunityCheck);
        healthBar.setMaxHealth(desired_MaxHealth);
        healthBar.setHealth(desired_MaxHealth);

        temp_FireRate = shootingPattern[0].getFireRate();
        temp_BulletSpeed = shootingPattern[0].getBulletSpeed();
        temp_Size = shootingPattern[0].getSize();
        temp_Bounce = shootingPattern[0].getBounce();
        temp_MoveSpeed = move.getMoveSpeed();

        temp_Health = healthBar.getHealth();

        nullNeeded = true;
    }

    private void Update()
    {
        vecPlayer.x = player.transform.position.x;
        vecPlayer.y = player.transform.position.y;
        vecEnemy.x = this.gameObject.transform.position.x;
        vecEnemy.y = this.gameObject.transform.position.y;
        angle = Vector2.Angle(vecEnemy, vecPlayer);
        ShootPoint_Aim.rotation = Quaternion.Euler(0, 0, angle);
    }

    //--------------------reset functions-----------------------

    public void resetFireRate() 
    { 
        foreach(Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setFireRate(temp_FireRate);
        }
    }

    public void resetBulletSpeed() 
    {
        foreach(Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setBulletSpeed(temp_BulletSpeed); 
        }
    }

    public void resetSpinSpeed() 
    { 
        foreach(BulletParticles particles in particles)
        {
            particles.setSpinSpeed(0);
        }
    }

    public void resetSize() 
    { 
        foreach(Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setSize(temp_Size);
        }
    }

    public void resetBounce() 
    { 
        foreach(Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setBounce(temp_Bounce);
        }
    }

    public void resetMoveSpeed() { move.setMoveSpeed(temp_MoveSpeed); }

    public void resetMaxHealth() { healthBar.setMaxHealth(desired_MaxHealth); }

    public void resetHealth() { healthBar.setHealth(temp_Health); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        resetMoveSpeed();
        move.setCanMove(false);
        foreach (Enemy_ShootingPattern pattern in shootingPattern)
        {
            pattern.setCanShoot(false);
        }
        resetSpinSpeed();
        resetFireRate();
        resetBulletSpeed();
        resetSize();
    }

    //----------------------basic actions-----------------------

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

    public void Shoot1()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[0].setCanShoot(true);
    }

    public void Spin1()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setCanShoot(true);
            particles[0].setSpinSpeed(desired_SpinSpeed);
        }

    public void Spin1Opposite()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setCanShoot(true);
            particles[0].setSpinSpeed(-1 * desired_SpinSpeed);
        }

    public void Shoot1FireFaster()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setFireRate(temp_FireRate * 2);
            shootingPattern[0].setCanShoot(true);
        }

    public void Shoot1FireSlower()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setFireRate((int)(temp_FireRate / 2));
            shootingPattern[0].setCanShoot(true);
        }

    public void Shoot1BulletFaster()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setBulletSpeed(temp_BulletSpeed * 2);
            shootingPattern[0].setCanShoot(true);
        }

    public void Shoot1BulletSlower()
        {
            if (nullNeeded)
            {
                actionNull();
            }
            shootingPattern[0].setBulletSpeed(temp_BulletSpeed / 2);
            shootingPattern[0].setCanShoot(true);
        }

    public void Shoot1FireFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1();
        Shoot1FireFaster();
        this.nullNeeded = true;
    }

    public void Shoot1FireSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1();
        Shoot1FireSlower();
        this.nullNeeded = true;
    }

    public void Shoot1BulletFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1();
        Shoot1BulletFaster();
        this.nullNeeded = true;
    }

    public void Shoot1BulletSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1();
        Shoot1BulletSlower();
        this.nullNeeded = true;
    }

    public void Shoot1FireFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1Opposite();
        Shoot1FireFaster();
        this.nullNeeded = true;
    }

    public void Shoot1FireSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1Opposite();
        Shoot1FireSlower();
        this.nullNeeded = true;
    }

    public void Shoot1BulletFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1Opposite();
        Shoot1BulletFaster();
        this.nullNeeded = true;
    }

    public void Shoot1BulletSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin1Opposite();
        Shoot1BulletSlower();
        this.nullNeeded = true;
    }

    public void Shoot2()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setCanShoot(true);
    }

    public void Spin2()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setCanShoot(true);
        particles[1].setSpinSpeed(desired_SpinSpeed);
    }

    public void Spin2Opposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setCanShoot(true);
        particles[1].setSpinSpeed(desired_SpinSpeed);
    }

    public void Shoot2FireFaster()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setFireRate(temp_FireRate * 2);
        shootingPattern[1].setCanShoot(true);
    }

    public void Shoot2FireSlower()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setFireRate((int)(temp_FireRate / 2));
        shootingPattern[1].setCanShoot(true);
    }

    public void Shoot2BulletFaster()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setBulletSpeed(temp_BulletSpeed * 2);
        shootingPattern[1].setCanShoot(true);
    }

    public void Shoot2BulletSlower()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setBulletSpeed(temp_BulletSpeed / 2);
        shootingPattern[1].setCanShoot(true);
    }

    public void Shoot2FireFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2();
        Shoot2FireFaster();
        this.nullNeeded = true;
    }

    public void Shoot2FireSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2();
        Shoot2FireSlower();
        this.nullNeeded = true;
    }

    public void Shoot2BulletFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2();
        Shoot2BulletFaster();
        this.nullNeeded = true;
    }

    public void Shoot2BulletSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2();
        Shoot2BulletSlower();
        this.nullNeeded = true;
    }

    public void Shoot2FireFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2Opposite();
        Shoot2FireFaster();
        this.nullNeeded = true;
    }

    public void Shoot2FireSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2Opposite();
        Shoot2FireSlower();
        this.nullNeeded = true;
    }

    public void Shoot2BulletFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2Opposite();
        Shoot2BulletFaster();
        this.nullNeeded = true;
    }

    public void Shoot2BulletSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        Spin2Opposite();
        Shoot2BulletSlower();
        this.nullNeeded = true;
    }

    public void aimAtPlayer()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[2].setCanShoot(true);
    }

    public void doNothing()
    {
        //nothing happens
    }

    //---------- simple action combos-------------------

    public void DashShoot1()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1();
        this.nullNeeded = true;
    }

    public void DashShoot1FireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireFaster();
        this.nullNeeded = true;
    }

    public void DashShoot1FireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireSlower();
        this.nullNeeded = true;
    }

    public void DashShoot1BulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletFaster();
        this.nullNeeded = true;
    }

    public void DashShoot1BulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletSlower();
        this.nullNeeded = true;
    }

    public void DashSpin1()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Spin1();
        this.nullNeeded = true;
    }

    public void DashSpin1FireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireFasterSpin();
        this.nullNeeded = true;
    }

    public void DashSpin1FireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireSlowerSpin();
        this.nullNeeded = true;
    }

    public void DashSpin1BulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletFasterSpin();
        this.nullNeeded = true;
    }

    public void DashSpin1BulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletSlowerSpin();
        this.nullNeeded = true;
    }

    public void DashSpin1Opposite()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Spin1Opposite();
        this.nullNeeded = true;
    }

    public void DashSpin1OppositeFireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireFasterSpinOpposite();
        this.nullNeeded = true;
    }

    public void DashSpin1OppositeFireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1FireSlowerSpinOpposite();
        this.nullNeeded = true;
    }

    public void DashSpin1OppositeBulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletFasterSpinOpposite();
        this.nullNeeded = true;
    }

    public void DashSpin1OppositeBulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        Shoot1BulletSlowerSpinOpposite();
        this.nullNeeded = true;
    }

    public void MoveShoot1()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1();
        this.nullNeeded = true;
    }

    public void MoveShoot1FireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireFaster();
        this.nullNeeded = true;
    }

    public void MoveShoot1FireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireSlower();
        this.nullNeeded = true;
    }

    public void MoveShoot1BulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletFaster();
        this.nullNeeded = true;
    }

    public void MoveShoot1BulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletSlower();
        this.nullNeeded = true;
    }

    public void MoveSpin1()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Spin1();
        this.nullNeeded = true;
    }

    public void MoveSpin1FireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireFasterSpin();
        this.nullNeeded = true;
    }

    public void MoveSpin1FireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireSlowerSpin();
        this.nullNeeded = true;
    }

    public void MoveSpin1BulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletFasterSpin();
        this.nullNeeded = true;
    }

    public void MoveSpin1BulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletSlowerSpin();
        this.nullNeeded = true;
    }

    public void MoveSpin1Opposite()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Spin1Opposite();
        this.nullNeeded = true;
    }

    public void MoveSpin1OppositeFireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireFasterSpinOpposite();
        this.nullNeeded = true;
    }

    public void MoveSpin1OppositeFireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1FireSlowerSpinOpposite();
        this.nullNeeded = true;
    }

    public void MoveSpin1OppositeBulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletFasterSpinOpposite();
        this.nullNeeded = true;
    }

    public void MoveSpin1OppositeBulletSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        Shoot1BulletSlowerSpinOpposite();
        this.nullNeeded = true;
    }

    public void Shoot1Spin2()
    {
        actionNull();
        this.nullNeeded = false;
        Shoot1();
        Spin2();
        this.nullNeeded = true;
    }

    public void Shoot1Spin2Opposite()
    {
        actionNull();
        this.nullNeeded = false;
        Shoot1();
        Spin2Opposite();
        this.nullNeeded = true;
    }

    public void Shoot1Shoot2FireFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Shoot1();
        Shoot2FireFaster();
        this.nullNeeded = true;
    }

    public void Shoot1Shoot2FireSlower()
    {
        actionNull();
        this.nullNeeded = false;
        Shoot1();
        Shoot2FireSlower();
        this.nullNeeded = true;
    }

    public void Shoot1Shoot2BulletFaster()
    {
        actionNull();
        this.nullNeeded = false;
        Shoot1();
        Shoot2BulletFaster();
        this.nullNeeded = true;
    }

    public void DashAimAtPLayer()
    {
        actionNull();
        this.nullNeeded = false;
        Dash();
        aimAtPlayer();
        this.nullNeeded = true;
    }

    public void MoveAimAtPlayer()
    {
        actionNull();
        this.nullNeeded = false;
        Movement();
        aimAtPlayer();
        this.nullNeeded = true;
    }


}
