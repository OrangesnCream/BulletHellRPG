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
        boomDistance = GetComponentInChildren<CircleCollider2D>().radius;
    }

    public void boom()
    {

    }
}
