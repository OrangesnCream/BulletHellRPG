using System.Collections;
using System.Threading;
using UnityEngine;

public class Barrel_pattern : MonoBehaviour
{
    private BarrelSpawner barrel;
    private Vector2 direction;
    private bool canShoot;
    public float speed;
    private int opportunity;
    public int opportunitycheck;

    //grab rigid body add gravity then stop it after 
    void Start()
    {
        barrel = GetComponent<BarrelSpawner>();
    }

    private void FixedUpdate()
    {
        if (canShoot)
        {
            barrel.needBarrels();
            foreach (var item in barrel.barrels)
            {
                item.SetActive(true);
                direction.y = Random.Range(-1, 1);
                direction.x = Random.Range(-1, 1);
                direction.Normalize();
                item.GetComponent<Rigidbody2D>().gravityScale = 1;
                item.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
        }

        opportunity++;

        if (opportunity >= opportunitycheck)
        {
            foreach (var item in barrel.barrels)
            {
                if (item.GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    item.GetComponent<Rigidbody2D>().gravityScale = 0;
                    item.GetComponent<Barrel_Hit>().setCanHit(true);
                    item.GetComponent<CapsuleCollider2D>().enabled = true;
                }
            }
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setSpeed(float speed) {  this.speed = speed; }
}
