using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
