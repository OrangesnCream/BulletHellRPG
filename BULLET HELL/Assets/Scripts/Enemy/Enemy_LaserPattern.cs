using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LaserPattern : MonoBehaviour
{
    private List<Transform> children;
    public List<LineRenderer> lineRenderers;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        children = GetChildren(transform);//for the barrel projectile do a thing where you give it a random vector & set velocity and set the gravity scale on then turn it off after a bit

        foreach (Transform child in children)
        {
            lineRenderers.Add(child.GetComponent<LineRenderer>());
        }
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
    void Update()
    {
        
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

    public void setWidth(float width)
    {
        foreach (LineRenderer line in lineRenderers)
        {
            line.SetWidth(width, width);
        }
    }
}
