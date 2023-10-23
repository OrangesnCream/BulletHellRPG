using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour
{
    private HealthBar healthBar;
    public Bar_Fade[] Bar_Fade;

    void Start()
    {
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//temp function
        {
            takeDamage(1);
        }
    }

    public void takeDamage(int damage)
    {
        healthBar.setHealth(healthBar.getHealth() - damage);// add healthbar fade in fade out
        foreach(Bar_Fade bar in Bar_Fade)
        {
            bar.fade();
        }
    }
}
