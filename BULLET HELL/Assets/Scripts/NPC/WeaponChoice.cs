using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class WeaponChoice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string weaponChoice = ((Ink.Runtime.StringValue)DialogueManager
            .GetInstance()
            .GetVariableState("weaponEquiped")).value;
        Debug.Log("weapon:"+weaponChoice);
        switch (weaponChoice) {
            case "":
                break;
            case "Sniper":
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Weapon_Active>().SetWeapon("Sniper");
                break;
            case "SMG":
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Weapon_Active>().SetWeapon("SMG");
                break;
            case "Shotgun":
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Weapon_Active>().SetWeapon("Shotgun");
                break;
            default:
                Debug.LogWarning("weapon choice not handled by switch statement: " + weaponChoice);
                break;
        }
    }
}
