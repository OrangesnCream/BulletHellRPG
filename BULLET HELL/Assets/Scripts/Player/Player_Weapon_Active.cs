using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon_Active : MonoBehaviour
{
    public bool Sniper = true;
    public bool Shotgun = false;
    public bool SMG = false;
    public bool Launcher=false;

    private GameObject SniperWeapon;
    private GameObject ShotgunWeapon;
    private GameObject SMGWeapon;
    private GameObject LauncherWeapon;
    // Start is called before the first frame update
    void Start()
    {
        SniperWeapon = GameObject.FindGameObjectWithTag("Weapon_Sniper").gameObject;
        ShotgunWeapon = GameObject.FindGameObjectWithTag("Weapon_Shotgun").gameObject;
        SMGWeapon = GameObject.FindGameObjectWithTag("Weapon_SMG").gameObject;
        LauncherWeapon = GameObject.FindGameObjectWithTag("Weapon_Launcher").gameObject;
        if(Sniper){
            Shotgun = false;
            SMG = false;
            Launcher=false;
        }
        if(Shotgun){
            Sniper = false;
            SMG = false;
            Launcher=false;
        }
        if(SMG){
            Sniper = false;
            Shotgun = false;
            Launcher=false;
        }
        if(Launcher){
            Sniper = false;
            Shotgun = false;
            SMG = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Sniper){
            SniperWeapon.SetActive(true);
            ShotgunWeapon.SetActive(false);
            SMGWeapon.SetActive(false);
            LauncherWeapon.SetActive(false);
        
        }
        if(Shotgun){
            SniperWeapon.SetActive(false);
            ShotgunWeapon.SetActive(true);
            SMGWeapon.SetActive(false);
            LauncherWeapon.SetActive(false);
        }
        if(SMG){
            SniperWeapon.SetActive(false);
            ShotgunWeapon.SetActive(false);
            SMGWeapon.SetActive(true);
            LauncherWeapon.SetActive(false);
        }
        if(Launcher){
            SniperWeapon.SetActive(false);
            ShotgunWeapon.SetActive(false);
            LauncherWeapon.SetActive(true);
            SMGWeapon.SetActive(false);
        }
    }

    public void SetWeapon(string weapon){
        if(weapon == "Sniper"){
            Sniper = true;
            Shotgun = false;
            SMG = false;
            Launcher=false;
        }
        if(weapon == "Shotgun"){
            Sniper = false;
            Shotgun = true;
            SMG = false;
            Launcher=false;
        }
        if(weapon == "SMG"){
            Sniper = false;
            Shotgun = false;
            SMG = true;
            Launcher=false;
        }
        if(weapon == "Launcher"){
            Sniper = false;
            Shotgun =false;
            SMG = false;
            Launcher=true;
        }
    }
}
