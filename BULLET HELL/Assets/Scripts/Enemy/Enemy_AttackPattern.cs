using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : MonoBehaviour
{
    public Enemy_Controller controller;
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
            pattern.Add(controller.Dash);
            pattern.Add(controller.Spin1);
            pattern.Add(controller.Movement);
            pattern.Add(controller.Spin1Opposite);
            pattern.Add(controller.DashShoot1);
            pattern.Add(controller.MoveSpin1Opposite);
            pattern.Add(controller.Shoot1);
            pattern.Add(controller.DashSpin1Opposite);
            pattern.Add(controller.DashSpin1);
            pattern.Add(controller.MoveSpin1);
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
