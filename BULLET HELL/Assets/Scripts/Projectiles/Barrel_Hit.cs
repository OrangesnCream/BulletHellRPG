using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Barrel_Hit : MonoBehaviour
{
    public LayerMask layerHit;
    public int lifeTime;
    private int it;
    private bool isHit;

    private Barrel_Explosion explosion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<Barrel_Explosion>();
        rb = GetComponent<Rigidbody2D>();

        isHit = false;
        it = 0;
    }

    private void FixedUpdate()
    {
        if (isHit)
            it++;

        if (it >= lifeTime)
        {
            explosion.boom();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit: " + collision.gameObject.layer);
        Debug.Log("hitmath: " + Mathf.Pow(2, collision.gameObject.layer));
        Debug.Log("LayerHit" + layerHit.value);
        if (Mathf.Pow(2, collision.gameObject.layer) == layerHit)
        {
            rb.velocity = collision.relativeVelocity;
            isHit = true;
        }
    }

    public void setIsHit(bool isHit) { this.isHit = isHit; }
}
