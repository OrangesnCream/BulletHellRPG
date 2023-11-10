using System;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public int number_of_barrels;
    public GameObject barrel;
    public List<GameObject> barrels;
    private bool moreBarrels;

    // Start is called before the first frame update
    void Start()
    {
        moreBarrels = true;
        barrels = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < number_of_barrels && moreBarrels; i++)
        {
            var go = Instantiate(barrel);
            go.name = "Barrel_" + i;
            barrels.Add(go);
            go.transform.position = this.gameObject.transform.position;
            go.SetActive(false);
            go.GetComponent<Barrel_Hit>().setCanHit(false);
        }
        moreBarrels = false;
    }

    public void needBarrels()
    {
        moreBarrels = true;
    }
}
