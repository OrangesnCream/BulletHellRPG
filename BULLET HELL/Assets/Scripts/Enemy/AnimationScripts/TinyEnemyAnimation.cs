using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyEnemyAnimation : MonoBehaviour
{
    private Enemy_Nav move;
     private Animator anim;
    private float speed;
    private Rigidbody2D rb;
    public Transform firePoint;

    private SpriteRenderer m_SpriteRenderer;
    private Vector2 enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        move = this.gameObject.GetComponent<Enemy_Nav>();
    }

    // Update is called once per frame
    void Update()
    {
       
        enemyMovement=rb.velocity;
         Debug.Log("test:"+enemyMovement.x);
        if(move.getMoveVelocity()!=Vector2.zero){
            anim.SetBool("IsRunning",true);
        }else{
            anim.SetBool("IsRunning",false);
        }
        if(move.getMoveVelocity().x > 0){
            m_SpriteRenderer.flipX=false;
            if(firePoint.localPosition.x<0){
                //flips the enemy gun right
                firePoint.localPosition = new Vector3(-firePoint.localPosition.x, firePoint.localPosition.y, firePoint.localPosition.z);
            }
        } else if(move.getMoveVelocity().x<0) {
             m_SpriteRenderer.flipX=true;
            if(firePoint.localPosition.x>0){
                //flips the enemy gun left
                firePoint.localPosition = new Vector3(-firePoint.localPosition.x, firePoint.localPosition.y, firePoint.localPosition.z);
            }
        }
        //add seperate transform flip for the gun


    }
}
