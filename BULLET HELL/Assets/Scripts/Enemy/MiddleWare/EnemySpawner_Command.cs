using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Command : MonoBehaviour
{
    private EnemySpawner_Pattern pattern;

    private bool nullNeeded;
    // Start is called before the first frame update
    void Start()
    {
        pattern = gameObject.GetComponent<EnemySpawner_Pattern>();  
    }

    //----------action nullifier---------------------

    public void actionNull()
    {
        pattern.setCanSpawn(false);
    }

    //----------------------actions-----------------------

    public void Spawn()
    {
        if (nullNeeded)
            actionNull();
        pattern.setCanSpawn(true);
    }

    public void doNothing()
    {
        //nothing happens
        actionNull();
    }
}
