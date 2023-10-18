using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private Enemy_Move move;
    private BulletParticles particles;
    private HealthBar healthBar;
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

    private void Start()
    {
        shootingPattern = this.gameObject.GetComponentInChildren<Enemy_ShootingPattern>();
        move = this.gameObject.GetComponent<Enemy_Move>();
        particles = this.gameObject.GetComponentInChildren<BulletParticles>();
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        particles.setSpinSpeed(desired_SpinSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);
        move.setMoveSpeed(desired_MoveSpeed);
        move.setMovementOpportunityCheck(desired_MoveOpportunityCheck);
        healthBar.setMaxHealth(desired_MaxHealth);

        temp_FireRate = shootingPattern.getFireRate();
        temp_BulletSpeed = shootingPattern.getBulletSpeed();
        temp_Size = shootingPattern.getSize();
        temp_Bounce = shootingPattern.getBounce();
        temp_MoveSpeed = move.getMoveSpeed();
        temp_Health = healthBar.getHealth();
    }

    //--------------------reset functions-----------------------

    public void resetFireRate() { shootingPattern.setFireRate(temp_FireRate); }

    public void resetBulletSpeed() { shootingPattern.setBulletSpeed(temp_BulletSpeed); }

    public void resetSpinSpeed() { particles.setSpinSpeed(0); }

    public void resetSize() { shootingPattern.setSize(temp_Size); }

    public void resetBounce() { shootingPattern.setBounce(temp_Bounce); }

    public void resetMoveSpeed() { move.setMoveSpeed(temp_MoveSpeed); }

    public void resetMaxHealth() { healthBar.setMaxHealth(desired_MaxHealth); }

    public void resetHealth() { healthBar.setHealth(temp_Health); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        resetMoveSpeed();
        move.setCanMove(false);
        shootingPattern.setCanShoot(false);
        resetSpinSpeed();
    }

    //----------------------basic actions-----------------------

    public void startDash()
    {
        actionNull();
        move.setMoveSpeed(this.dashMultiplier * this.desired_MoveSpeed);
        move.setCanMove(true);
    }

    public void startMovement()
    {
        actionNull();
        move.setCanMove(true);
    }

    public void startShoot()
    {
        actionNull();
        shootingPattern.setCanShoot(true);
    }

    public void startSpin()
    {
        actionNull();
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(desired_SpinSpeed);
    }

    public void startSpinOpposite()
    {
        actionNull();
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(-1 * desired_SpinSpeed);
    }

    //----------action combos-------------------

    public void startDashShoot()
    {
        actionNull();
        startDash();
        startShoot();
    }

    public void startDashSpin()
    {
        actionNull();
        startDash();
        startSpin();
    }

    public void startDashSpinOpposite()
    {
        actionNull();
        startDash();
        startSpinOpposite();
    }

    public void startMoveShoot()
    {
        actionNull();
        startMovement();
        startShoot();
    }

    public void startMoveSpin()
    {
        actionNull();
        startMovement();
        startSpin();
    }

    public void startMoveSpinOpposite()
    {
        actionNull();
        startMovement();
        startSpinOpposite();
    }
}
