using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grunt_1_Pattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_ShootAimCommand shootAimCommand;

    private Opportunity_Timer timer;

    public HealthBar healthBar;

    public List<Action> patternMove;
    public List<Action> patternAim;

    public int oppurtinutycheck;
    private int iterator;
    private bool added1;

    void Start()
    {
        timer = this.gameObject.GetComponent<Opportunity_Timer>();
        timer.setOpportunity(oppurtinutycheck);

        patternMove = new List<Action>();
        patternAim = new List<Action>();

        iterator = 0;
        added1 = false;
    }

    private void Update()
    {
        if (!added1)
        {
            patternMove.Add(moveCommand.Movement); patternAim.Add(shootAimCommand.Shoot);
            patternMove.Add(moveCommand.Movement); patternAim.Add(shootAimCommand.doNothing);

            added1 = true;
        }

        //-------pattern part-------------------


        if (iterator >= patternMove.Count)
            this.iterator = 0;

        if (timer.getOpportunity() > oppurtinutycheck && timer.state())
        {
            patternMove[iterator].Invoke();
            patternAim[iterator].Invoke();
            this.iterator++;

            timer.setOpportunity(0);
        }

        if (!timer.state())
        {
            CancelInvoke();
        }
    }
}
