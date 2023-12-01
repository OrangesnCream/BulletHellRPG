using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grunt_2_Pattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_LaserCommand laser1Command;
    public Enemy_LaserAimCommand laserAimCommand;

    private Opportunity_Timer timer;

    public Enemy_HealthBar healthBar;

    public List<Action> patternMove;
    public List<Action> patternLaser1;
    public List<Action> patternLaserAim;

    public int oppurtinutycheck;
    private int iterator;
    private bool added1;

    void Start()
    {
        timer = this.gameObject.GetComponent<Opportunity_Timer>();
        timer.setOpportunity(oppurtinutycheck);

        patternMove = new List<Action>();
        patternLaser1 = new List<Action>();
        patternLaserAim = new List<Action>();


        iterator = 0;
        added1 = false;
    }

    private void Update()
    {
        if (!added1)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            patternMove.Add(moveCommand.doNothing); patternLaser1.Add(laser1Command.doNothing);         patternLaserAim.Add(laserAimCommand.Shoot);
            patternMove.Add(moveCommand.Movement);  patternLaser1.Add(laser1Command.doNothing);         patternLaserAim.Add(laserAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternLaser1.Add(laser1Command.Shoot);             patternLaserAim.Add(laserAimCommand.doNothing);

            added1 = true;
        }

        //-------pattern part-------------------

        if (iterator >= patternMove.Count)
            this.iterator = 0;

        if (timer.getOpportunity() > oppurtinutycheck && timer.state())
        {
            patternMove[iterator].Invoke();
            patternLaser1[iterator].Invoke();
            patternLaserAim[iterator].Invoke();
            this.iterator++;

            timer.setOpportunity(0);
        }

        if (!timer.state())
        {
            CancelInvoke();
        }
    }
}
