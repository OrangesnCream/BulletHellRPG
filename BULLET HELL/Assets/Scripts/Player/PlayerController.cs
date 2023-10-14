using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float sprintSpeed = 15f;
    private float speed = 10f;

    private Vector2 lastDirection = new Vector2(0, -1);

    public Rigidbody2D rb;

    public PlayerStats ps;

    Vector2 movement;

    private bool isDevMode = false;

    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //TODO: get controller inputs for following
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = sprintSpeed;
        } else {
            speed = baseSpeed;
        }

        if(movement.x != 0 || movement.y != 0){
            lastDirection = movement;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Dash();
        }

        if(Input.GetKeyDown(KeyCode.F1)){
            isDevMode = !isDevMode;
            if(isDevMode){
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log("Dev mode enabled");
            }
            else{
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("Dev mode disabled");
            }
        }
    }

    void FixedUpdate(){
        Move();
    }

    void Move(){
        rb.velocity = movement.normalized * speed;
    }

    void Dash(){
        if(ps.dashCooldown <= 0){
            rb.AddForce(lastDirection * (ps.dashMultiplier * 5000));
            ps.resetDashCooldown();
        }
    }
    
}
