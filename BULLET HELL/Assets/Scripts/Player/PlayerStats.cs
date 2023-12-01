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

    public int baseShieldCooldown = 1000;
    public int shieldCooldown = 0;
    public ShieldBar shieldBar;

    public float baseDamageInvincibilityTime = 1.0f;
    public float damageInvincibilityTime = 0f;

    public GameObject deathScreen;

    public PlayerController pc;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);

        dashBar.setMaxDash(baseDashCooldown);
        dashBar.setDash(dashCooldown);

        shieldBar.setMaxShield(baseShieldCooldown);
        shieldBar.setShield(shieldCooldown);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     takeDamage(20);
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     heal(20);
        // }
    }

    private void OnParticleCollision(GameObject other)
    {
        takeDamage(10);
    }

    void FixedUpdate()
    {
        dashTimer();
        damageTimer();
        shieldTimer();
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

    public void shieldTimer(){
        if(shieldCooldown > 0){
            shieldCooldown -= (int)(Time.deltaTime * 200);
        }
        shieldBar.setShield(shieldCooldown);
    }

    public void resetDashCooldown(){
        dashCooldown = baseDashCooldown;
    }

    public void resetShieldCooldown(){
        shieldCooldown = baseShieldCooldown;
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
        if (currentHealth <= 0){
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        pc.isDead = true;
        Time.timeScale = .25f;
        Debug.Log("Player died");

        yield return new WaitForSeconds(1f);

        Time.timeScale = 0f;
        deathScreen.SetActive(true);
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
