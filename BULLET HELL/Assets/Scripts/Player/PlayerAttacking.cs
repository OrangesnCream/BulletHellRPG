using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Attacking : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canFire = true;
    public float fireRate = 0.5f;
    private float shootTimer = 0.0f;

    public GameObject shield;
    public float shieldRange = 2.0f;
    public int shieldDamage = 33;
    public float shieldDuration = 0.5f;
    public bool canShield = true;

    private PlayerController pc;
    private PlayerStats ps;

    public bool isShotgun = false;

    public AudioSource gunSound;
    public AudioSource pumpSound;
    //public AudioSource shieldSound;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pc = transform.parent.gameObject.GetComponent<PlayerController>();
        ps = transform.parent.gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.isDash || pc.isDead || Time.timeScale < 1f){
            return;
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //flips gun
        if(mousePos.x > transform.position.x){
            firePoint.localScale = new Vector3(1f, 1f, 1f);
        } else {
            firePoint.localScale = new Vector3(1f, -1f, 1f);
        }

        if(Input.GetMouseButton(0) && canFire){
            Shoot();
        }

        if(Input.GetMouseButtonDown(1) && canShield){
            StartCoroutine(Shield());
        }
    }

    void FixedUpdate(){
        if(!canFire){
            ShootTimer();
        }

        if(!canShield){
            ps.shieldTimer();
        }

        if(ps.shieldCooldown <= 0){
            canShield = true;
        }
    }

    void Shoot(){
        //play shoot animation
        if(!isShotgun){
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        if(isShotgun){
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        gunSound.Play();
        if(pumpSound != null){
            pumpSound.PlayDelayed(gunSound.clip.length);
        }
        canFire = false;
    }

    private IEnumerator Shield(){
        //play shield animation
        shield.GetComponent<CircleCollider2D>().enabled = true;
        shield.GetComponent<SpriteRenderer>().enabled = true;

        canShield = false;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(shield.transform.position, shieldRange, Vector2.zero, 0.0f);
        foreach(RaycastHit2D hit in hits){
            if(hit.transform.gameObject.tag == "Enemy"){
                Debug.Log("Hit " + hit.transform.gameObject.name + " for " + (shieldDamage) + " damage");
                hit.transform.gameObject.GetComponent<Enemy_Hit>().takeDamage(shieldDamage);
            }
        }

        ps.damageInvincibilityTime = 200f;
        ps.resetShieldCooldown();

        yield return new WaitForSeconds(shieldDuration); //.25

        shield.GetComponent<CircleCollider2D>().enabled = false;
        shield.GetComponent<SpriteRenderer>().enabled = false;

        ps.damageInvincibilityTime = 0f;
    }

    void ShootTimer(){
        shootTimer += Time.deltaTime;
        if(shootTimer >= fireRate){
            canFire = true;
            shootTimer = 0.0f;
        }
    }

}
