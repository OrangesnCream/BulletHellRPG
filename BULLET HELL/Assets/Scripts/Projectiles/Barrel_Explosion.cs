using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Barrel_Explosion : MonoBehaviour
{
    public float boomDistance;

    private byte countdown;
    private Color color;
    private byte r;
    private byte g;
    private byte b;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<CircleCollider2D>().radius = 0f;
        GetComponentInChildren<Image>().enabled = false;

        countdown = 255;
        color = GetComponentInChildren<Image>().color;
        r = (byte)(color.r * 255);
        g = (byte)(color.g * 255);
        b = (byte)(color.b * 255);
    }

    private void Update()
    {
        if (GetComponentInChildren<Image>().enabled)
        {
            GetComponentInChildren<Image>().color = new Color32(r, b, g, countdown);
            countdown -= (byte) 5;
        }

        if (countdown <= (byte) 5)
        {
            Destroy(this.gameObject);
        }
    }

    public void boom()
    {
        GetComponentInChildren<CircleCollider2D>().radius = boomDistance;
        GetComponentInChildren<Image>().enabled = true;
    }
}
