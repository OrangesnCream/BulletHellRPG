using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_Shoot1Command Shoot1Command;
    public Enemy_Shoot2Command shoot2Command;
    public Enemy_ShootAimCommand shootAimCommand;

    public HealthBar healthBar;

    public List<Action> patternMove;
    public List<Action> patternShoot1;
    public List<Action> patternShoot2;
    public List<Action> patternShootAim;

    public int oppurtinutycheck;
    private int patternopportunity;
    private int iterator;
    private bool added1;
    private bool added2;
    private bool added3;
    public bool halfpattern;
    public bool fourthpattern;

    private bool half;
    private bool fourth;
    // Start is called before the first frame update
    void Start()
    {
        patternMove = new List<Action>();
        patternShoot1 = new List<Action>();
        patternShoot2 = new List<Action>();
        patternShootAim = new List<Action>();


        patternopportunity = oppurtinutycheck;
        iterator = 0;
        added1 = false;
        added2 = false;
        added3 = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!added1)//health patterns || boss specific attacks || change hitbox for 2.5d look
        {
            patternMove.Add(moveCommand.Dash);      patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Movement);  patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.BulletSlower);              patternShoot2.Add(shoot2Command.BulletSlowerSpin);          patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Movement);  patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Dash);      patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.FireFasterSpin);            patternShoot2.Add(shoot2Command.FireFasterSpinOpposite);    patternShootAim.Add(shootAimCommand.aimAtPlayer);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.aimAtPlayer);
            patternMove.Add(moveCommand.Movement);  patternShoot1.Add(Shoot1Command.doNothing);                 patternShoot2.Add(shoot2Command.doNothing);                 patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.FireFasterSpinOpposite);    patternShoot2.Add(shoot2Command.BulletSlower);              patternShootAim.Add(shootAimCommand.doNothing);

            added1 = true;
        }

        else if (!added2 && halfpattern && healthBar.getHealth() <= healthBar.getMaxHealth() / 2)
        {
            patternMove.Clear();                    patternShoot1.Clear();                                      patternShoot2.Clear();                                      patternShootAim.Clear();



            added2 = true;
        }

        else if (!added3 && fourthpattern && healthBar.getHealth() <= healthBar.getMaxHealth() / 4)
        {
            patternMove.Clear();                    patternShoot1.Clear();                                      patternShoot2.Clear();                                      patternShootAim.Clear();



            added3 = true;
        }

        //-------pattern part-------------------

        patternopportunity++;

        if(patternopportunity >= oppurtinutycheck)
        {
            pattern();

            patternopportunity = 0;
        }
    }

    public void pattern()
    {
        if (iterator >= patternMove.Count)
        {
            this.iterator = 0;
        }
        else
        {
            patternMove[iterator].Invoke();
            patternShoot1[iterator].Invoke();
            patternShoot2[iterator].Invoke();
            patternShootAim[iterator].Invoke();
            Debug.Log(iterator);
            this.iterator++;
        }
    }
}
