using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float sprintSpeed = 15f;
    private float speed = 10f;

    public Transform AnimationDirection;//to flip animation
    private SpriteRenderer m_SpriteRenderer;
    private Vector2 lastDirection = new Vector2(0, -1);
    public bool isDash = false;
    private bool canDash = true;

    public Rigidbody2D rb;

    public PlayerStats ps;

    private TrailRenderer tr;

    Vector2 movement;

    private bool isDevMode = false;

    private Player_Weapon_Active pwa;

    public GameObject pauseMenu;

    public bool isDead = false;

    private Animator anim;//for setting animation

    //stair code

    const float StairSlowDownXPos = 0.8f;
    const float StairSlowDownXNeg = 0.6f;
    const float StairSlowDownYPos = 0.8f;
    const float StairSlowDownYNeg = 0.6f;

    public Stack<Stairs> CurrentStairs = new Stack<Stairs>();


    void Start(){
        anim=GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        tr = gameObject.transform.GetComponent<TrailRenderer>();
        pwa = gameObject.transform.GetComponent<Player_Weapon_Active>();
    }

    void Update(){
        if(isDead){
            //set all movement to 0
            movement = new Vector2(0, 0);
            return;
        }

        if(Input.GetKeyDown(KeyCode.Tab)){
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if(pauseMenu.activeSelf){
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }
        }

        //if timescale is = 0, then the game is paused
        if(Time.timeScale == 0f){
            return;
        }

        if(isDash){
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //TODO: get controller inputs for following
        //player sprinting, not in use
        // if(Input.GetKey(KeyCode.LeftShift)){
        //     speed = sprintSpeed;
        // } else {
        //     speed = baseSpeed;
        // }

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

            if(Input.GetKeyDown(KeyCode.Alpha1)){
                pwa.SetWeapon("Sniper");
                Debug.Log("Sniper");
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                pwa.SetWeapon("Shotgun");
                Debug.Log("Shotgun");
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                pwa.SetWeapon("SMG");
                Debug.Log("SMG");
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                pwa.SetWeapon("Launcher");
                Debug.Log("Launcher");
            }          
        //set player animation
        
        if(movement.x!=0||movement.y!=0){
            anim.SetBool("IsRunning",true);
        }else{
            anim.SetBool("IsRunning",false);
        }
        
        //player anim flip
        if(movement.x > 0){
            m_SpriteRenderer.flipX=false;
           // AnimationDirection.localScale = new Vector3(1f, 1f, 1f);
        } else if(movement.x<0) {
             m_SpriteRenderer.flipX=true;
          //  AnimationDirection.localScale = new Vector3(-1f, 1f, 1f);
        }


    }

    void FixedUpdate(){
        if (GameObject.FindGameObjectsWithTag("NPC").Length != 0) {
            if (DialogueManager.GetInstance().dialogueIsPlaying) {
                Debug.Log("freeze movement");
                //freezes player during dialogue
                isDead = true;
                return;
            }
            else {
                isDead = false;
            }
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
        if (CurrentStairs.Count == 0){
        rb.velocity = movement.normalized * speed;
        }
        Stairs stairs = CurrentStairs.Peek();
        Vector2 stairsDirection = stairs.GetDirection();

        // apply slows for vertical direction
        movement.y *= (Mathf.Sign(stairsDirection.y) == Mathf.Sign(movement.y)) ? StairSlowDownYNeg : StairSlowDownYPos;
        float originalLength = movement.magnitude;

        float angle = stairs.Angle;
        bool isVertical = angle == 0;

        // since we are using the range 0-180, we need to do some clean up in the angle here
        // I'm sure there is a cleaner way to do this, but it works so whatever.
        bool isRight = angle > 90;
        if (isRight) {
        angle = angle - 90;
        } else {
        angle = 90 - angle;
        }
        // calculate tan, negate based on the angle because of math
        float tan = -Mathf.Tan(angle * Mathf.Deg2Rad);
        if (isRight) {
        tan *= -1;
        }
        // For vertical stairs we need to override this to 0 since it will increase y infinitely when our angle is 0
        if (isVertical)
        tan = 0;

        // SPECIFIC CASE: Player walks diagonally down stairs
        // This results in the player not moving in the y direction (cancels out due to tan angle)
        // we allow them to move a bit because even though its "logically" correct, it feels restrictive.
        // This is a perfect example of not following exact realism for the sake of game-feel
        if (Mathf.Sign(stairsDirection.x) != Mathf.Sign(movement.x) && movement.y > 0) {
        tan /= 2;
        }
        // apply vector calc to y and normalize to maintain speed
        movement.y += movement.x * tan;
        movement = movement.normalized * originalLength;
        rb.velocity=movement*speed;
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
