using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootAimCommand : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private BulletParticles particles;
    private GameObject player;
    public GameObject enemy;

    public int desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;

    private bool nullNeeded;
    private Vector2 direction;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        shootingPattern = this.GetComponent<Enemy_ShootingPattern>();
        particles = this.GetComponent<BulletParticles>();
        player = GameObject.FindGameObjectWithTag("Player");

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);

        particles.setSpinSpeed(desired_SpinSpeed);

        nullNeeded = true;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = player.transform.position.x - enemy.transform.position.x;
        direction.y = player.transform.position.y - enemy.transform.position.y;
        angle = (Mathf.Atan2(direction.y, direction.x) * 180) / Mathf.PI;

        if(particles.getColumns() > 1)
        {
            angle += particles.getDegrees() / 4;
        }

        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
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

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
