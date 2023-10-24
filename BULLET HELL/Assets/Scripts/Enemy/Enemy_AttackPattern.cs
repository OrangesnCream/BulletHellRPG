using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : MonoBehaviour
{
    public Enemy_Controller controller;
    public List<Action> patternMove;
    public List<Action> patternShoot1;
    public List<Action> patternShoot2;
    public List<Action> patternShootAim;

    public int oppurtinutycheck;
    private int patternopportunity;
    private int iterator;
    private bool added;
    public bool half;
    // Start is called before the first frame update
    void Start()
    {
        patternMove = new List<Action>();
        patternShoot1 = new List<Action>();
        patternShoot2 = new List<Action>();
        patternShootAim = new List<Action>();

        patternopportunity = oppurtinutycheck;
        iterator = 0;
        added = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!added)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            patternMove.Add(controller.Dash);  patternShoot1.Add(controller.Dash);
            patternMove.Add(controller.doNothing);
            patternMove.Add(controller.Movement);
            patternMove.Add(controller.doNothing);
            patternMove.Add(controller.doNothing);
            added = true;
        }

        patternopportunity++;

        if(patternopportunity >= oppurtinutycheck)
        {
            if (iterator >= pattern1.Count)
            {
                iterator = 0;
            }
            else
            {
                pattern1[iterator].Invoke();
                Debug.Log(pattern1[iterator].Method.Name);
                iterator++;
            }

            patternopportunity = 0;
        }
    }
}
