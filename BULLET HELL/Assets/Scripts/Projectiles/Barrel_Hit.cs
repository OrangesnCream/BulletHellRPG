using UnityEngine;
using UnityEngine.UI;

public class Barrel_Hit : MonoBehaviour
{
    public LayerMask layerHit;
    public LayerMask layerBoom;
    public int lifeTime;
    private int it;
    private bool isHit;
    private bool canHit;
    private bool boomtime;

    private Barrel_Explosion explosion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<Barrel_Explosion>();
        rb = GetComponent<Rigidbody2D>();

        isHit = false;
        it = 0;
        canHit = true;
        boomtime = false;
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (isHit || boomtime)
            it++;

        if (it >= lifeTime)
        {
            explosion.boom();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isHit && (layerBoom.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)// bit shifting stuff idk what it does
        {
            rb.isKinematic = false;
            explosion.boom();
        }
        else if (canHit && (layerHit.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer) // 1<< shifts bits left by 1
        {
            rb.isKinematic = false;
            rb.velocity = collision.relativeVelocity / 3;
            isHit = true;
        }
    }

    public void setCanHit(bool canHit) { this.canHit = canHit; }

    public void setIsHit(bool isHit) { this.isHit = isHit; }

    public void setLifeTime(int lifeTime) 
    { 
        this.lifeTime = lifeTime;
        boomtime = true;
    }
}
