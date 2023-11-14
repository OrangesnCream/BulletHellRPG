using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grunt_1_Pattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_ShootAimCommand shootAimCommand;

    public HealthBar healthBar;

    public List<Action> patternMove;
    public List<Action> patternAim;

    public int oppurtinutycheck;
    private int patternopportunity;
    private int iterator;
    private bool added1;

    void Start()
    {
        patternMove = new List<Action>();
        patternAim = new List<Action>();

        patternopportunity = oppurtinutycheck;
        iterator = 0;
        added1 = false;
    }

    private void FixedUpdate()
    {
        if (!added1)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            patternMove.Add(moveCommand.Movement); patternAim.Add(shootAimCommand.Shoot);
            patternMove.Add(moveCommand.Movement); patternAim.Add(shootAimCommand.doNothing);

            added1 = true;
        }

        //-------pattern part-------------------

        patternopportunity++;

        if (iterator >= patternMove.Count)
            this.iterator = 0;

        if (patternopportunity > oppurtinutycheck)
        {
            patternMove[iterator].Invoke();
            patternAim[iterator].Invoke();
            this.iterator++;

            patternopportunity = 0;
        }
    }
}
