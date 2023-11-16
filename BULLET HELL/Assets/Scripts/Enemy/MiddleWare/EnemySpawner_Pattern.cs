using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Pattern : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            _enemySpawner.needMinions();
            canSpawn = false;
        }
    }

    public void setCanSpawn(bool canSpawn) { this.canSpawn = canSpawn; }
}
