using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float dashMultiplier = 2f;
    public int baseDashCooldown = 200;
    public int dashCooldown = 0;
    public DashBar dashBar;

    public float baseDamageInvincibilityTime = 1.0f;
    public float damageInvincibilityTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);

        dashBar.setMaxDash(baseDashCooldown);
        dashBar.setDash(dashCooldown);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            heal(20);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        takeDamage(10);
    }

    void FixedUpdate()
    {
        dashTimer();
        damageTimer();
    }

    void damageTimer()
    {
        if (damageInvincibilityTime > 0)
        {
            damageInvincibilityTime -= Time.deltaTime;
        }
    }

    void dashTimer(){
        if(dashCooldown > 0){
            dashCooldown -= (int)(Time.deltaTime * 200);
        }
        dashBar.setDash(dashCooldown);
    }

    public void resetDashCooldown(){
        dashCooldown = baseDashCooldown;
    }

    public void takeDamage(int damage)
    {
        if (damageInvincibilityTime > 0)
        {
            Debug.Log("Player is invincible");
            return;
        }
        damageInvincibilityTime = baseDamageInvincibilityTime;
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        Debug.Log("Player Health: " + currentHealth);
    }

    public void heal(int heal)
    {
        if(currentHealth + heal > maxHealth){
            currentHealth = maxHealth;
        }
        else{
            currentHealth += heal;
        }
        healthBar.setHealth(currentHealth);
        Debug.Log("Player Health: " + currentHealth);
    }
}
