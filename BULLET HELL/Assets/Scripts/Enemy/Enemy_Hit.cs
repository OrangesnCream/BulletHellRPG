using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour
{
    private HealthBar healthBar;

    void Start()
    {
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();
    }

    public void takeDamage(int damage)
    {
        healthBar.setHealth(healthBar.getHealth() - damage);
    }
}
