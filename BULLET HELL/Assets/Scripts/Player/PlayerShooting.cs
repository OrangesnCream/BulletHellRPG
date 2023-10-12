using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canFire = true;
    public float fireRate = 0.5f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

        if(!canFire){
            ShootTimer();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        canFire = false;
    }

    void ShootTimer(){
        timer += Time.deltaTime;
        if(timer >= fireRate){
            canFire = true;
            timer = 0.0f;
        }
    }
}
