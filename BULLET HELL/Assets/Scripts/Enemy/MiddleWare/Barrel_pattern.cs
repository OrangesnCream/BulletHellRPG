using System.Collections;
using System.Threading;
using UnityEngine;

public class Barrel_pattern : MonoBehaviour
{
    private BarrelSpawner barrel;
    private Vector2 direction;
    private bool canShoot;
    private float speed;
    private int opportunity;
    private bool active;

    //grab rigid body add gravity then stop it after 
    void Start()
    {
        barrel = GetComponent<BarrelSpawner>();
        active = false;
    }

    private void FixedUpdate()
    {
        if (canShoot)
        {
            barrel.needBarrels();
            Debug.Log(barrel.getBarrels().Count);
            foreach (GameObject item in barrel.getBarrels())
            {
                direction.y = Random.Range(-1, 1);
                direction.x = Random.Range(-1, 1);
                direction.Normalize();
                item.GetComponent<Rigidbody2D>().gravityScale = 1;
                item.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
            active = true;
            canShoot = false;
        }
        if (active)
        {
            opportunity++;
        }

        if (opportunity >= 100)
        {
            foreach (GameObject item in barrel.getBarrels())
            {
                if (item.GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    item.GetComponent<Rigidbody2D>().gravityScale = 0;
                    item.GetComponent<Barrel_Hit>().setCanHit(true);
                    item.GetComponent<CapsuleCollider2D>().enabled = true;
                    item.GetComponentInChildren<CircleCollider2D>().enabled = true;
                }
            }
            barrel.getBarrels().Clear();
            active = false;
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setSpeed(float speed) {  this.speed = speed; }
}
