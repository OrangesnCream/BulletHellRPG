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
    private float temp_SpinSpeed;
    private float temp_Size;
    private int temp_Bounce;
    private int temp_ShootOpportunityCheck;
    private float temp_MoveSpeed;
    private float temp_MoveOpportunityCheck;
    private int temp_Health;

    public int desired_FireRate;
    public float desired_BulletSpeed;
    public float desired_SpinSpeed;
    public float desired_Size;
    public int desired_Bounce;
    public int desired_ShootOpportunityCheck;
    public float desired_MoveSpeed;
    public float desired_MoveOpportunityCheck;
    public int desired_MaxHealth;

    // Start is called before the first frame update
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
        shootingPattern.setOpportunityCheck(desired_ShootOpportunityCheck);
        move.setMoveSpeed(desired_MoveSpeed);
        move.setMovementOpportunityCheck(desired_MoveOpportunityCheck);
        healthBar.setMaxHealth(desired_MaxHealth);

        temp_FireRate = shootingPattern.getFireRate();
        temp_BulletSpeed = shootingPattern.getBulletSpeed();
        temp_SpinSpeed = particles.getSpinSpeed();
        temp_Size = shootingPattern.getSize();
        temp_Bounce = shootingPattern.getBounce();
        temp_ShootOpportunityCheck = shootingPattern.getOpportunityCheck();
        temp_MoveSpeed = move.getMoveSpeed();
        temp_MoveOpportunityCheck = move.getMovementOpportunityCheck();
        temp_Health = healthBar.getHealth();
    }

    public void resetFireRate() { shootingPattern.setFireRate(temp_FireRate); }

    public void resetBulletSpeed() { shootingPattern.setBulletSpeed(temp_BulletSpeed); }

    public void resetSpinSpeed() { particles.setSpinSpeed(temp_SpinSpeed); }

    public void resetSize() { shootingPattern.setSize(temp_Size); }

    public void resetBounce() { shootingPattern.setBounce(temp_Bounce); }

    public void resetShootOpportunityCheck() { shootingPattern.setOpportunityCheck(temp_ShootOpportunityCheck); }

    public void resetMoveSpeed() { move.setMoveSpeed(temp_MoveSpeed); }

    public void resetMoveOpportunityCheck() { move.setMovementOpportunityCheck(desired_MoveOpportunityCheck); }

    public void resetMaxHealth() { healthBar.setMaxHealth(desired_MaxHealth); }

    public void resetHealth() { healthBar.setHealth(temp_Health); }
}
