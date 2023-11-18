using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int number_of_minions;
    public GameObject minion;
    public List<GameObject> minions;
    private bool moreMinion;
    private float angle;

    void Start()
    {
        moreMinion = false;
        this.minions = new List<GameObject>();
        angle = 360 / number_of_minions;
    }

    void Update()
    {
        for (int i = 0; i < number_of_minions && moreMinion; i++)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle * i);
            Vector3 SpawnAround = new Vector3(gameObject.GetComponentInParent<Transform>().position.x + gameObject.transform.right.x * 5, gameObject.GetComponentInParent<Transform>().position.y + gameObject.transform.right.y * 5, 0);
            var go = Instantiate(minion, SpawnAround, Quaternion.Euler(0, 0, 0));
            go.name = "Minion_" + i;
            this.minions.Add(go);
            go.GetComponent<LineOfSight>().sightDistance = 1000f;
        }
        minions.Clear();
        moreMinion = false;
    }

    public void needMinions()
    {
        moreMinion = true;
    }

    public List<GameObject> getMinions() { return this.minions; }
}
