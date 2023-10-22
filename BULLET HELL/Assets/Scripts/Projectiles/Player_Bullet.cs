using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private Camera cam;
    private Rigidbody2D rb;
    public float speed = 20f;
    public int bulletDamage = 10;
    public float lifeTime = 5f;
    public bool canPierce = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        direction = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = direction - transform.position;
        Vector3 rotation = transform.position - direction;
        rb.velocity = new Vector2(lookDir.x, lookDir.y).normalized * speed;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Hit enemy: " + other.gameObject.name);
            //other.gameObject.GetComponent<Enemy>().takeDamage(bulletDamage);
            
        }
        if(other.gameObject.tag != "Background" && other.gameObject.tag != "Player"){
            if(!canPierce){
                Destroy(gameObject);
            }
        }
    }
}
