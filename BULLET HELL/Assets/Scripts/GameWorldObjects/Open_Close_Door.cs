using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Open_Close_Door : MonoBehaviour
{
    private Tilemap doors;
    private TilemapCollider2D doorCollider;
    private TilemapRenderer doorShow;
    private bool isOpen;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        doors = this.gameObject.GetComponentInParent<Tilemap>();
        doorCollider = this.gameObject.GetComponentInParent<TilemapCollider2D>();
        doorShow = this.gameObject.GetComponentInParent<TilemapRenderer>();
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            if(boss != null && boss.GetComponentInParent<LineOfSight>().isSighted())
            {
                isOpen = false;
            }
            
            doors.enabled = false;
            doorCollider.enabled = false;
            doorShow.enabled = false;
        }
        else
        {
            doors.enabled = true;
            doorCollider.enabled = true;
            doorShow.enabled = true;

        }
    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if(entity.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            boss = entity.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D entity)
    {
        if(entity.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            isOpen = true;
        }
    }
}
