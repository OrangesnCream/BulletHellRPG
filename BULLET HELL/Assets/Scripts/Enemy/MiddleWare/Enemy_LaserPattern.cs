using System.Collections.Generic;
using UnityEngine;

public class Enemy_LaserPattern : MonoBehaviour
{
    private List<Transform> children;
    public List<LineRenderer> lineRenderers;

    public int Desired_Damage;
    private LaserMaker laserMaker;
    private LayerMask LayerMask;

    private bool canShoot;
    private bool canHit;

    void Start()
    {
        children = GetChildren(transform);//for the barrel projectile do a thing where you give it a random vector & set velocity and set the gravity scale on then turn it off after a bit

        foreach (Transform child in children)
        {
            lineRenderers.Add(child.GetComponent<LineRenderer>());
        }

        laserMaker = GetComponent<LaserMaker>();
        canShoot = false;
        canHit = false;
        LayerMask = laserMaker.getLayerMask();
    }

    private List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }

    void Update()//draw the raycast hits
    {
        if (!canHit)
        {
            foreach (Transform child in children)
            {
                child.tag = "NoReg";
            }
        }
        else if (canHit)
        {
            foreach (Transform child in children)
            {
                child.tag = GetComponentInParent<Transform>().tag;
            }
        }

        if (canShoot)
        {
            foreach (LineRenderer child in lineRenderers)
            {
                child.SetPosition(0, this.transform.position);
                RaycastHit2D hit = Physics2D.Raycast(child.transform.position, child.transform.forward, 1000f, LayerMask);
                child.SetPosition(1, hit.point);

                if (hit.transform.tag == "Player" && child.tag != "NoReg")
                {
                    hit.transform.GetComponent<PlayerStats>().takeDamage(Desired_Damage);
                }
            }
            foreach (LineRenderer line in lineRenderers)
            {
                if (!line.enabled)
                {
                    line.enabled = true;
                }
            }
        }
        else if (!canShoot)
        {
            foreach (LineRenderer line in lineRenderers)
            {
                if (line.enabled)
                {
                    line.enabled = false;
                }
            }
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setWidth(float width)
    {
        foreach (LineRenderer line in lineRenderers)
        {
            line.startWidth = width;
            line.endWidth = width;
        }
    }

    public void setCanHit(bool canHit) { this.canHit = canHit; }
}
