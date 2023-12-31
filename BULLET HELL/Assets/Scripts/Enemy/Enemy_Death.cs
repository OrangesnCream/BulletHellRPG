using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public Enemy_HealthBar healthBar;
    public SpriteRenderer sprite;
    private byte countdown;
    private Color color;
    private byte r;
    private byte g;
    private byte b;

    void Start()
    {
        countdown = 255;
        color = sprite.color;
        r = (byte)(color.r * 255);
        g = (byte)(color.g * 255);
        b = (byte)(color.b * 255);
    }

    void FixedUpdate()
    {
        if (healthBar.getHealth() <= 0)
        {
            sprite.color = new Color32(r, b, g, countdown);
            countdown -= 10;
        }

        if (countdown <= (byte) 10)
        {
            Destroy(this.gameObject);
        }
    }
}
