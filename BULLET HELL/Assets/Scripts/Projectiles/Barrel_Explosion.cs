using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel_Explosion : MonoBehaviour
{
    public LayerMask layerBoom;
    public float boomDistance;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<CircleCollider2D>().radius = 0f;
        GetComponentInChildren<Image>().enabled = false;
    }

    public void boom()
    {
        GetComponentInChildren<CircleCollider2D>().radius = boomDistance;
        GetComponentInChildren<Image>().enabled = true;
    }
}
