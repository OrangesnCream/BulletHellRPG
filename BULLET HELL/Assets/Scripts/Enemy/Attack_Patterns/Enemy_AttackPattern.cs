using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : MonoBehaviour
{
    public Enemy_Shoot1Command Shoot1Command;
    public Enemy_Shoot2Command shoot2Command;
    public Enemy_ShootAimCommand shootAimCommand;
    public List<Action> pattern;

    public int oppurtinutycheck;
    private int patternopportunity;
    private int iterator;
    private bool added;
    public bool half;
    // Start is called before the first frame update
    void Start()
    {
        pattern = new List<Action>();

        patternopportunity = oppurtinutycheck;
        iterator = 0;
        added = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!added)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            added = true;
        }

        patternopportunity++;

        if(patternopportunity >= oppurtinutycheck)
        {
            if (iterator >= pattern.Count)
            {
                iterator = 0;
            }
            else
            {
                pattern[iterator].Invoke();
                Debug.Log(pattern[iterator].Method.Name);
                iterator++;
            }

            patternopportunity = 0;
        }
    }
}
