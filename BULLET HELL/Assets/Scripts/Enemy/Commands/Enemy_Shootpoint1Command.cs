using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Enemy_Shoot1Command : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private BulletParticles particles;

    private int temp_FireRate;
    private float temp_BulletSpeed;
    private float temp_Size;
    private int temp_Bounce;

    public int desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;

    private bool nullNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        shootingPattern = this.gameObject.GetComponent<Enemy_ShootingPattern>();
        particles = this.gameObject.GetComponent<BulletParticles>();

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);

        particles.setSpinSpeed(desired_SpinSpeed);

        temp_FireRate = desired_FireRate;
        temp_BulletSpeed = desired_BulletSpeed;
        temp_Size = desired_Size;
        temp_Bounce = desired_Bounce;

        nullNeeded = true;
    }

    //--------------------reset functions-----------------------

    public void resetFireRate()
    {
        shootingPattern.setFireRate(temp_FireRate);
    }

    public void resetBulletSpeed()
    {
        shootingPattern.setBulletSpeed(temp_BulletSpeed);
    }

    public void resetSpinSpeed()
    {
        particles.setSpinSpeed(0);
    }

    public void resetSize()
    {
        shootingPattern.setSize(temp_Size);
    }

    public void resetBounce()
    {
        shootingPattern.setBounce(temp_Bounce);
    }

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
        {
            actionNull();
        }
        shootingPattern.setCanShoot(true);
    }

    public void Spin()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(desired_SpinSpeed);
    }

    public void SpinOpposite()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setCanShoot(true);
        particles.setSpinSpeed(-1 * desired_SpinSpeed);
    }

    public void ShootFireFaster()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setFireRate(temp_FireRate * 2);
        shootingPattern.setCanShoot(true);
    }

    public void ShootFireSlower()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setFireRate((int)(temp_FireRate / 2));
        shootingPattern.setCanShoot(true);
    }

    public void ShootBulletFaster()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setBulletSpeed(temp_BulletSpeed * 2);
        shootingPattern.setCanShoot(true);
    }

    public void ShootBulletSlower()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setBulletSpeed(temp_BulletSpeed / 2);
        shootingPattern.setCanShoot(true);
    }

    public void ShootFireFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        ShootFireFaster();
        this.nullNeeded = true;
    }

    public void ShootFireSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        ShootFireSlower();
        this.nullNeeded = true;
    }

    public void ShootBulletFasterSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        ShootBulletFaster();
        this.nullNeeded = true;
    }

    public void ShootBulletSlowerSpin()
    {
        actionNull();
        this.nullNeeded = false;
        Spin();
        ShootBulletSlower();
        this.nullNeeded = true;
    }

    public void ShootFireFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        ShootFireFaster();
        this.nullNeeded = true;
    }

    public void ShootFireSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        ShootFireSlower();
        this.nullNeeded = true;
    }

    public void ShootBulletFasterSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        ShootBulletFaster();
        this.nullNeeded = true;
    }

    public void ShootBulletSlowerSpinOpposite()
    {
        actionNull();
        this.nullNeeded = false;
        SpinOpposite();
        ShootBulletSlower();
        this.nullNeeded = true;
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
