using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon_Active : MonoBehaviour
{
    public bool Sniper = true;
    public bool Shotgun = false;
    public bool SMG = false;

    private GameObject SniperWeapon;
    private GameObject ShotgunWeapon;
    private GameObject SMGWeapon;
    // Start is called before the first frame update
    void Start()
    {
        SniperWeapon = GameObject.FindGameObjectWithTag("Weapon_Sniper").gameObject;
        ShotgunWeapon = GameObject.FindGameObjectWithTag("Weapon_Shotgun").gameObject;
        SMGWeapon = GameObject.FindGameObjectWithTag("Weapon_SMG").gameObject;
        if(Sniper){
            Shotgun = false;
            SMG = false;
        }
        if(Shotgun){
            Sniper = false;
            SMG = false;
        }
        if(SMG){
            Sniper = false;
            Shotgun = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Sniper){
            SniperWeapon.SetActive(true);
            ShotgunWeapon.SetActive(false);
            SMGWeapon.SetActive(false);
        }
        if(Shotgun){
            SniperWeapon.SetActive(false);
            ShotgunWeapon.SetActive(true);
            SMGWeapon.SetActive(false);
        }
        if(SMG){
            SniperWeapon.SetActive(false);
            ShotgunWeapon.SetActive(false);
            SMGWeapon.SetActive(true);
        }
    }

    public void SetWeapon(string weapon){
        if(weapon == "Sniper"){
            Sniper = true;
            Shotgun = false;
            SMG = false;
        }
        if(weapon == "Shotgun"){
            Sniper = false;
            Shotgun = true;
            SMG = false;
        }
        if(weapon == "SMG"){
            Sniper = false;
            Shotgun = false;
            SMG = true;
        }
    }
}
