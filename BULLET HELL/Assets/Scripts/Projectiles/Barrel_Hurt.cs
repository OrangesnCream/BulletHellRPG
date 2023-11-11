using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Hurt : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.GetComponent<Enemy_Hit>().takeDamage(damage);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerStats>().takeDamage(damage);
        }
    }
}
