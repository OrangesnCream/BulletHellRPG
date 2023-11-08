using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Explosion : MonoBehaviour
{
    public LayerMask layerBoom;
    public float boomDistance;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<CircleCollider2D>().radius = 0f;
    }

    public void boom()
    {
        GetComponentInChildren<CircleCollider2D>().radius = boomDistance;
    }
}
