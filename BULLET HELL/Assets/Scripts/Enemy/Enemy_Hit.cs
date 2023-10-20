using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour
{
    private HealthBar healthBar;
    private Bar_Fade Bar_Fade;

    void Start()
    {
        healthBar = this.gameObject.GetComponentInChildren<HealthBar>();
        Bar_Fade = this.gameObject.GetComponentInChildren<Bar_Fade>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            takeDamage(1);
        }
    }

    public void takeDamage(int damage)
    {
        healthBar.setHealth(healthBar.getHealth() - damage);// add healthbar fade in fade out
        Debug.Log("took " + damage + " hp");
        Bar_Fade.fade();
    }
}
