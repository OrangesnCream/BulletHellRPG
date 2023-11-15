using Ink.Parsed;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Engine_Pattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_Shoot1Command Shoot1Command;
    public Enemy_Shoot2Command shoot2Command;
    public Enemy_Laser1Command laser1Command;
    public Enemy_LaserAimCommand laserAimCommand;
    public Barrel_Command barrelCommand;

    private Opportunity_Timer timer;

    public HealthBar healthBar;

    public List<Action> patternMove;
    public List<Action> patternShoot1;
    public List<Action> patternShoot2;
    public List<Action> patternLaser1;
    public List<Action> patternLaserAim;
    public List<Action> patternBarrel;

    public int oppurtinutycheck;
    private int iterator;
    private bool added1;
    private bool added2;
    public bool halfpattern;

    void Start()
    {
        timer = this.gameObject.GetComponent<Opportunity_Timer>();
        timer.setOpportunity(oppurtinutycheck);

        patternMove = new List<Action>();
        patternShoot1 = new List<Action>();
        patternShoot2 = new List<Action>();
        patternLaser1 = new List<Action>();
        patternLaserAim = new List<Action>();
        patternBarrel = new List<Action>();

        iterator = 0;
        added1 = false;
        added2 = false;
    }

    private void FixedUpdate()
    {
        if (!added1)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.BulletSlower);              patternShoot2.Add(shoot2Command.BulletSlowerSpin);          patternLaser1.Add(laser1Command.Shoot);         patternLaserAim.Add(laserAimCommand.doNothing);     patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.FireFasterSpin);            patternShoot2.Add(shoot2Command.FireFasterSpinOpposite);    patternLaser1.Add(laser1Command.Spin);          patternLaserAim.Add(laserAimCommand.doNothing);     patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternLaser1.Add(laser1Command.SpinOpposite);  patternLaserAim.Add(laserAimCommand.doNothing);     patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.FireFasterSpinOpposite);    patternShoot2.Add(shoot2Command.BulletSlower);              patternLaser1.Add(laser1Command.doNothing);     patternLaserAim.Add(laserAimCommand.Shoot);         patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternLaser1.Add(laser1Command.doNothing);     patternLaserAim.Add(laserAimCommand.SwingClock);    patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternLaser1.Add(laser1Command.doNothing);     patternLaserAim.Add(laserAimCommand.SwingCounter);  patternBarrel.Add(barrelCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternLaser1.Add(laser1Command.doNothing);     patternLaserAim.Add(laserAimCommand.doNothing);     patternBarrel.Add(barrelCommand.Shoot);

            added1 = true;
        }

        else if (!added2 && halfpattern && healthBar.getHealth() <= healthBar.getMaxHealth() / 2)
        {
            patternMove.Clear(); patternShoot1.Clear(); patternShoot2.Clear(); patternLaser1.Clear(); patternLaserAim.Clear();



            added2 = true;
        }

        //-------pattern part-------------------

        if (iterator >= patternMove.Count)
            this.iterator = 0;

        if (timer.getOpportunity() >= oppurtinutycheck && timer.state())
        {
            patternMove[iterator].Invoke();
            patternShoot1[iterator].Invoke();
            patternShoot2[iterator].Invoke();
            patternLaser1[iterator].Invoke();
            patternLaserAim[iterator].Invoke();
            patternBarrel[iterator].Invoke();
            Debug.Log("move: " + iterator);
            this.iterator++;

            timer.setOpportunity(0);
        }

        if (!timer.state())
        {
            CancelInvoke();
        }
    }
}
