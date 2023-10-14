using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Enemy_ShootingPattern shootingPattern;
    private Enemy_Move move;
    private BulletParticles particles;
    private float tempFireRate;
    private float tempBulletSpeed;
    private float tempSpinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        shootingPattern = this.gameObject.GetComponentInChildren<Enemy_ShootingPattern>();
        move = this.gameObject.GetComponent<Enemy_Move>();
        particles = this.gameObject.GetComponentInChildren<BulletParticles>();

        tempFireRate = shootingPattern.getFireRate();
        tempBulletSpeed = shootingPattern.getBulletSpeed();
        tempSpinSpeed = particles.getSpinSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
