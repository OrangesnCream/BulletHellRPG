using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxDash(int dash)
    {
        slider.maxValue = dash;
        slider.value = dash;
    }

    public void setDash(int dash)
    {
        slider.value = slider.maxValue - dash;
        if(dash <= 0){
            slider.value = slider.maxValue;
        }
    }
}
