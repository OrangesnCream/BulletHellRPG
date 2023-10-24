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

    public void startDash()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        move.setMoveSpeed(this.dashMultiplier * this.desired_MoveSpeed);
        move.setCanMove(true);
    }

    public void startMovement()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        move.setCanMove(true);
    }

    public void startShoot()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[0].setCanShoot(true);
    }

    public void startSpin()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[0].setCanShoot(true);
        particles[0].setSpinSpeed(desired_SpinSpeed);
    }

    public void startSpinOpposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[0].setCanShoot(true);
        particles[0].setSpinSpeed(-1 * desired_SpinSpeed);
    }

    public void start2Spin()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setCanShoot(true);
        particles[1].setSpinSpeed(desired_SpinSpeed);
    }

    public void start2SpinOpposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern[1].setCanShoot(true);
        particles[1].setSpinSpeed(desired_SpinSpeed);
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

    //----------action combos-------------------

    public void startDashShoot()
    {
        actionNull();
        this.nullNeeded = false;
        startDash();
        startShoot();
        this.nullNeeded = true;
    }

    public void startDashSpin()
    {
        actionNull();
        this.nullNeeded = false;
        startDash();
        startSpin();
        this.nullNeeded = true;
    }

    public void startDashSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        startDash();
        startSpinOpposite();
        this.nullNeeded = true;
    }

    public void startMoveShoot()
    {
        actionNull();
        this.nullNeeded = false;
        startMovement();
        startShoot();
        this.nullNeeded = true;
    }

    public void startMoveSpin()
    {
        actionNull();
        this.nullNeeded = false;
        startMovement();
        startSpin();
        this.nullNeeded = true;
    }

    public void startMoveSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        startMovement();
        startSpinOpposite();
        this.nullNeeded = true;
    }
}
