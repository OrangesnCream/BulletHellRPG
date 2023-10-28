using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float sprintSpeed = 15f;
    private float speed = 10f;

    private Vector2 lastDirection = new Vector2(0, -1);
    public bool isDash = false;
    private bool canDash = true;

    public Rigidbody2D rb;

    public PlayerStats ps;

    private TrailRenderer tr;

    Vector2 movement;

    private bool isDevMode = false;

    void Start(){
        tr = gameObject.transform.GetComponent<TrailRenderer>();
    }

    void Update(){
        if(isDash){
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //TODO: get controller inputs for following
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = sprintSpeed;
        } else {
            speed = baseSpeed;
        }

        if(movement.x != 0 || movement.y != 0){
            lastDirection = movement.normalized;
        }

        if(Input.GetKeyDown(KeyCode.Space) && canDash){
            StartCoroutine(Dash());
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
       if (DialogueManager.GetInstance().dialogueIsPlaying) {
            //freezes player during dialogue
            return;
        }
        if(isDash){
            return;
        }
        Move();
        if(ps.dashCooldown <= 0){
            canDash = true;
        }
    }

    void Move(){
        rb.velocity = movement.normalized * speed;
    }

    private IEnumerator Dash(){
        canDash = false;
        isDash = true;

        ps.damageInvincibilityTime = 200f;
        ps.resetDashCooldown();

        tr.emitting = true;

        rb.velocity = lastDirection * (ps.dashMultiplier * speed);

        yield return new WaitForSeconds(.25f);

        ps.damageInvincibilityTime = 0f;
        isDash = false;

        tr.emitting = false;
    }
    
}
