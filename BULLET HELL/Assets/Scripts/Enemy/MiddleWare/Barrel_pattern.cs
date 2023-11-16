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
            foreach (GameObject item in barrel.getBarrels())
            {
                direction.y = Random.Range(-0.5f, 2.0f);
                direction.x = Random.Range(-1.0f, 1.0f);
                //direction.Normalize();
                item.SetActive(true);
                item.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
                item.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
            active = true;
            canShoot = false;
        }
        if (active)
        {
            opportunity++;
            if (opportunity <= 40)
            {
                foreach (GameObject item in barrel.getBarrels())
                {
                    item.transform.localScale =  new Vector3(Mathf.Lerp(1f, 1.5f, opportunity / 40),Mathf.Lerp(1f, 1.5f, opportunity / 40),0);
                }
            }
            else
            {
                foreach (GameObject item in barrel.getBarrels())
                {
                    item.transform.localScale = new Vector3(Mathf.Lerp(1.5f, 1f, (opportunity- 40) / 40), Mathf.Lerp(1.5f, 1f, (opportunity - 40) / 40), 0);
                }
            }
            
        }

        if (opportunity >= 80)
        {
            foreach (GameObject item in barrel.getBarrels())
            {
                item.GetComponent<Rigidbody2D>().gravityScale = 0;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                item.GetComponent<Barrel_Hit>().setCanHit(true);
                item.GetComponent<Barrel_Hit>().setLifeTime(300);
                item.GetComponent<CapsuleCollider2D>().enabled = true;
                item.GetComponentInChildren<CircleCollider2D>().enabled = true;
            }
            barrel.getBarrels().Clear();
            barrel.needBarrels();
            active = false;
            opportunity = 0;
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setSpeed(float speed) {  this.speed = speed; }
}
