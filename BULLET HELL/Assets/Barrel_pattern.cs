using System.Collections;
using UnityEngine;

public class Barrel_pattern : MonoBehaviour
{
    private BarrelSpawner barrel;
    private Vector2 direction;
    private bool canShoot;
    private float speed;

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
                //do it on a timer to stop them
            }
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setSpeed(float speed) {  this.speed = speed; }
}
