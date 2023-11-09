using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private Transform player;
    public Transform enemy;

    public float sightDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()//
    {
        Vector2 distance = player.position - enemy.position;
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y,2)); //too fuking lazy to do raycast pythag ez
        if (hypotenuse > sightDistance)
        {
            enemy.gameObject.SetActive(false);
        }
        else
        {
            enemy.gameObject.SetActive(true);
        }
    }
}
