using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canFire = true;
    public float fireRate = 0.5f;
    private float shootTimer = 0.0f;

    public Transform meleePoint;
    public float meleeRange = 1.0f;
    public float meleeDamage = 33.5f;
    public bool canMelee = true;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        meleePoint.localScale = new Vector3(meleeRange*2, meleeRange*2, 1.0f);
        meleePoint.position = firePoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Input.GetMouseButton(0) && canFire){
            Shoot();
        }

        if(Input.GetMouseButtonDown(1)){
            Melee();
        }

        if(!canFire){
            ShootTimer();
        }
    }

    void Shoot(){
        //play shoot animation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        canFire = false;
    }

    void Melee(){
        //play melee animation
        RaycastHit2D[] hits = Physics2D.CircleCastAll(firePoint.position, meleeRange, transform.right, 0.0f);
        foreach(RaycastHit2D hit in hits){
            if(hit.transform.gameObject.tag == "Enemy"){
                Debug.Log("Hit " + hit.transform.gameObject.name + " for " + (meleeDamage) + " damage");
                // hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(meleeDamage);
            }
        }
        // canMelee = false; //TODO: canMelee = true when animation is done
    }

    void ShootTimer(){
        shootTimer += Time.deltaTime;
        if(shootTimer >= fireRate){
            canFire = true;
            shootTimer = 0.0f;
        }
    }
}
