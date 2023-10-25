using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : MonoBehaviour
{
    public Enemy_moveCommand moveCommand;
    public Enemy_Shoot1Command Shoot1Command;
    public Enemy_Shoot2Command shoot2Command;
    public Enemy_ShootAimCommand shootAimCommand;
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
            patternMove.Add(moveCommand.Dash);      patternShoot1.Add(Shoot1Command.doNothing);                     patternShoot2.Add(shoot2Command.doNothing);                     patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Movement);  patternShoot1.Add(Shoot1Command.doNothing);                     patternShoot2.Add(shoot2Command.doNothing);                     patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.ShootBulletSlower);             patternShoot2.Add(shoot2Command.ShootBulletSlowerSpin);         patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Movement);  patternShoot1.Add(Shoot1Command.doNothing);                     patternShoot2.Add(shoot2Command.doNothing);                     patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.Dash);      patternShoot1.Add(Shoot1Command.doNothing);                     patternShoot2.Add(shoot2Command.doNothing);                     patternShootAim.Add(shootAimCommand.doNothing);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.ShootFireFasterSpin);           patternShoot2.Add(shoot2Command.ShootFireFasterSpinOpposite);   patternShootAim.Add(shootAimCommand.aimAtPlayer);
            patternMove.Add(moveCommand.doNothing); patternShoot1.Add(Shoot1Command.doNothing);                     patternShoot2.Add(shoot2Command.doNothing);                     patternShootAim.Add(shootAimCommand.aimAtPlayer);

            added = true;
        }

        patternopportunity++;

        if(patternopportunity >= oppurtinutycheck)
        {
            if (iterator >= patternMove.Count)
            {
                iterator = 0;
            }
            else
            {
                patternMove[iterator].Invoke();
                patternShoot1[iterator].Invoke();
                patternShoot2[iterator].Invoke();
                patternShootAim[iterator].Invoke();
                Debug.Log(iterator);
                iterator++;
            }

            patternopportunity = 0;
        }
    }
}
