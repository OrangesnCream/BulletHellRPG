using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public float shootcheck;
    public float bulletspeed;

    private float shootopportunity;
    private Vector2 direction;

    private void Start()
    {
        direction = -transform.up;
    }

    void FixedUpdate()
    {
        shootopportunity++;

        if (shootopportunity >= shootcheck)
        {
            fire();
            shootopportunity = 0;
        }
    }

    private void fire()
    {
        GameObject bullet = Enemy_Projectile_Pool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = this.gameObject.transform.position;
            bullet.transform.rotation = this.gameObject.transform.rotation;
            bullet.SetActive(true);
            bullet.gameObject.GetComponent<Rigidbody2D>().velocity = bulletspeed * direction;
        }
    }
}
