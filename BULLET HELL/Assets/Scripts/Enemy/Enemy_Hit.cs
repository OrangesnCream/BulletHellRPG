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

    public void takeDamage(int damage)
    {
        healthBar.setHealth(healthBar.getHealth() - damage);// add healthbar fade in fade out
        foreach(Bar_Fade bar in Bar_Fade)
        {
            bar.fade();
        }
    }

    private void Update()
    {//test delete later
        if(Input.GetMouseButtonDown(0))
        {
            takeDamage(1);
        }
    }
}
