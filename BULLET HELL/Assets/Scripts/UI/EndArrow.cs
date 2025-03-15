using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject Arrow;

    void Start()
    {
        Arrow.SetActive(false);
        InvokeRepeating("CheckForBoss", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckForBoss(){
        if(Boss == null){
            Arrow.SetActive(true);
        }
    }
}
