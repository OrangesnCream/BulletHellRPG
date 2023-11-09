using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxShield(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }

    public void setShield(int shield)
    {
        slider.value = slider.maxValue - shield;
        if(shield <= 0){
            slider.value = slider.maxValue;
        }
    }
}
