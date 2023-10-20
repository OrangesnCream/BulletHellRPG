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
        if(!added)
        {
            pattern.Add(controller.startDash);
            pattern.Add(controller.startSpin);
            pattern.Add(controller.startMovement);
            pattern.Add(controller.startSpinOpposite);
            pattern.Add(controller.startDashShoot);
            pattern.Add(controller.startMoveSpinOpposite);
            pattern.Add(controller.startShoot);
            pattern.Add(controller.startDashSpinOpposite);
            pattern.Add(controller.startDashSpin);
            pattern.Add(controller.startMoveSpin);
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
