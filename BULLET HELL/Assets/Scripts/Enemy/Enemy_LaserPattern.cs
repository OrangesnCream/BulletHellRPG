using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Enemy_LaserPattern : MonoBehaviour
{
    private List<Transform> children;
    public List<LineRenderer> lineRenderers;

    private LaserMaker laserMaker;

    private bool canShoot;
    private bool canAim;
    private bool canSpin;
    // Start is called before the first frame update
    void Start()
    {
        children = GetChildren(transform);//for the barrel projectile do a thing where you give it a random vector & set velocity and set the gravity scale on then turn it off after a bit

        foreach (Transform child in children)
        {
            lineRenderers.Add(child.GetComponent<LineRenderer>());
        }

        laserMaker = GetComponent<LaserMaker>();
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

    // Update is called once per frame
    void Update()//do the spin here & draw the raycast hits
    {
        foreach(LineRenderer child in lineRenderers)
        {
            child.SetPosition(0, Vector3.zero);
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, child.transform.forward, 1000f, laserMaker.getLayerMask());

            child.SetPosition(1, hit.transform.position);

            Debug.Log(hit.transform.position);
        }

        if (canShoot)
        {
            
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setWidth(float width)
    {
        foreach (LineRenderer line in lineRenderers)
        {
            line.SetWidth(width, width);
        }
    }

    public void setCanAim(bool canAim) { this.canAim = canAim; }
}
