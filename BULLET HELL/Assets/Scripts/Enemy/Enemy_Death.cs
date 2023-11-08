using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public HealthBar healthBar;
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

    void Update()
    {
        if (healthBar.getHealth() == 0)
        {
            sprite.color = new Color32(r, b, g, countdown);
            countdown--;
        }

        if (countdown == (byte) 0)
        {
            Destroy(this.gameObject);
        }
    }
}
