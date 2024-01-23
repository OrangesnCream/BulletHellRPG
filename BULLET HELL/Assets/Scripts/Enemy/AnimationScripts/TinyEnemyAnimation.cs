using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyEnemyAnimation : MonoBehaviour
{
    private Enemy_Nav move;
     private Animator anim;
    private float speed;
    private Rigidbody2D rb;

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
        } else if(move.getMoveVelocity().x<0) {
             m_SpriteRenderer.flipX=true;
          
        }
        //add seperate transform flip for the gun

    }
}
