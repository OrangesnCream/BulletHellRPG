using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootAimCommand : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private BulletParticles particles;
    private GameObject player;
    public GameObject enemy;

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
    private Vector2 direction;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        shootingPattern = this.gameObject.GetComponent<Enemy_ShootingPattern>();
        particles = this.gameObject.GetComponent<BulletParticles>();
        player = GameObject.FindGameObjectWithTag("Player");

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);

        particles.setSpinSpeed(desired_SpinSpeed);

        temp_FireRate = shootingPattern.getFireRate();
        temp_BulletSpeed = shootingPattern.getBulletSpeed();
        temp_Size = shootingPattern.getSize();
        temp_Bounce = shootingPattern.getBounce();

        nullNeeded = true;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = player.transform.position.x - enemy.transform.position.x;
        direction.y = player.transform.position.y - enemy.transform.position.y;
        angle = Vector2.Angle(direction, Vector2.right);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
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

    public void aimAtPlayer()
    {
        if (nullNeeded)
        {
            actionNull();
        }
        shootingPattern.setCanShoot(true);
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
