using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private Transform player;
    public Transform enemy;
    public Canvas healthbar;
    public Enemy_Hit Enemy_Hit;

    public float sightDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy.gameObject.GetComponent<Opportunity_Timer>().enabled = false;
        healthbar.enabled = false;
        Enemy_Hit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = player.position - enemy.position;
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y,2)); //too fuking lazy to do raycast pythag ez
        if (hypotenuse <= sightDistance)
        {
            enemy.gameObject.GetComponent<Opportunity_Timer>().enabled = true;
            healthbar.enabled = true;
            Enemy_Hit.enabled = true;
        }
    }

    public bool isSighted()
    {
        Vector2 distance = player.position - enemy.position;
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y,2));
        return hypotenuse <= sightDistance;
    }
}
