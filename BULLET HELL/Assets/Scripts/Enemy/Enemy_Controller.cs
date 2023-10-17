using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private Enemy_Move move;
    private BulletParticles particles;
    private int tempFireRate;
    private float tempBulletSpeed;
    private float tempSpinSpeed;
    private float tempSize;
    private int tempBounce;
    private int tempOpportunityCheck;

    public int desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;
    public int desired_OpportunityCheck;

    // Start is called before the first frame update
    void Start()
    {
        shootingPattern = this.gameObject.GetComponentInChildren<Enemy_ShootingPattern>();
        move = this.gameObject.GetComponent<Enemy_Move>();
        particles = this.gameObject.GetComponentInChildren<BulletParticles>();

        shootingPattern.setFireRate(desired_FireRate);
        shootingPattern.setBulletSpeed(desired_BulletSpeed);
        particles.setSpinSpeed(desired_SpinSpeed);
        shootingPattern.setSize(desired_Size);
        shootingPattern.setBounce(desired_Bounce);
        shootingPattern.setOpportunityCheck(desired_OpportunityCheck);


        tempFireRate = shootingPattern.getFireRate();
        tempBulletSpeed = shootingPattern.getBulletSpeed();
        tempSpinSpeed = particles.getSpinSpeed();
        tempSize = shootingPattern.getSize();
        tempBounce = shootingPattern.getBounce();
        tempOpportunityCheck = shootingPattern.getOpportunityCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
