using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Hurt : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && collision.GetComponentInParent<LineOfSight>().getSeen())
        {
            collision.GetComponent<Enemy_Hit>().takeDamage(damage * 2);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerStats>().takeDamage(damage);
        }
    }
}
