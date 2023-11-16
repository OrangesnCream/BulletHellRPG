using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Enemy_Shoot1Command : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private BulletParticles particles;

    public float desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;

    private bool nullNeeded;
    // Start is called before the first frame update
    void Start()
    {
        shootingPattern = this.GetComponent<Enemy_ShootingPattern>();
        particles = this.GetComponent<BulletParticles>();

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);

        particles.setSpinSpeed(desired_SpinSpeed);

        nullNeeded = true;
    }

    //--------------------reset functions-----------------------

    public void resetFireRate() { shootingPattern.setFireRate(desired_FireRate); }

    public void resetBulletSpeed() { shootingPattern.setBulletSpeed(desired_BulletSpeed); }

    public void resetSpinSpeed() { particles.setSpinSpeed(0); }

    public void resetSize() { shootingPattern.setSize(desired_Size); }

    public void resetBounce() { shootingPattern.setBounce(desired_Bounce); }

    //----------action nullifier---------------------

    public void actionNull()
    {
        shootingPattern.setCanShoot(false);
        resetSpinSpeed();
        resetFireRate();
        resetBulletSpeed();
        resetSize();
    }

    //----------------------actions-----------------------

    public void Shoot()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setCanShoot(true);
    }

    public void Spin()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(desired_SpinSpeed);
    }

    public void SpinOpposite()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(-1 * desired_SpinSpeed);
    }

    public void FireFaster()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setFireRate(desired_FireRate * 2);
        shootingPattern.setCanShoot(true);
    }

    public void FireSlower()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setFireRate((desired_FireRate / 2));
        shootingPattern.setCanShoot(true);
    }

    public void BulletFaster()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setBulletSpeed(desired_BulletSpeed * 2);
        shootingPattern.setCanShoot(true);
    }

    public void BulletSlower()
    {
        if (nullNeeded)
            actionNull();
        shootingPattern.setBulletSpeed(desired_BulletSpeed / 2);
        shootingPattern.setCanShoot(true);
    }

    public void FireFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        FireFaster();
        this.nullNeeded = true;
    }

    public void FireSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        FireSlower();
        this.nullNeeded = true;
    }

    public void BulletFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        BulletFaster();
        this.nullNeeded = true;
    }

    public void BulletSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        BulletSlower();
        this.nullNeeded = true;
    }

    public void FireFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        FireFaster();
        this.nullNeeded = true;
    }

    public void FireSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        FireSlower();
        this.nullNeeded = true;
    }

    public void BulletFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        BulletFaster();
        this.nullNeeded = true;
    }

    public void BulletSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        BulletSlower();
        this.nullNeeded = true;
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
