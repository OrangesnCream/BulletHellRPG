using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int number_of_minions;
    public GameObject minion;
    public List<GameObject> minions;
    private bool moreMinion;

    // Start is called before the first frame update
    void Start()
    {
        moreMinion = false;
        this.minions = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < number_of_minions && moreMinion; i++)
        {
            var go = Instantiate(minion);
            go.name = "Minion_" + i;
            this.minions.Add(go);
            go.transform.position = this.gameObject.transform.forward;
            go.GetComponent<LineOfSight>().sightDistance = 1000f;
        }
        moreMinion = false;
    }

    public void needMinions()
    {
        moreMinion = true;
    }

    public List<GameObject> getMinions() { return this.minions; }
}
