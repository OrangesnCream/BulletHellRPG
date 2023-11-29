using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour
{
    private Enemy_HealthBar healthBar;
    public Bar_Fade[] Bar_Fade;

    void Start()
    {
        healthBar = this.gameObject.GetComponentInChildren<Enemy_HealthBar>();
    }

    public void takeDamage(int damage)
    {
        healthBar.damage(damage);// add healthbar fade in fade out
        foreach(Bar_Fade bar in Bar_Fade)
        {
            bar.fade();
        }
    }
}
