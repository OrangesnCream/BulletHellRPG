using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image healthColor;
    public Image inlineColor;
    public int maxHealth;
    private int currentHealth;
    public int stacks;
    private int currentStack;
    public Gradient gradient;
    private GradientColorKey[] ColorKeys;
    private GradientAlphaKey[] AlphaKeys;

    // Start is called before the first frame update
    void Start()
    {
        currentStack = stacks;
        currentHealth = maxHealth;
        this.slider.maxValue = maxHealth / stacks;
        this.slider.value = maxHealth / stacks;
        this.gradient.mode = GradientMode.Fixed;

        ColorKeys = new GradientColorKey[stacks];
        AlphaKeys = new GradientAlphaKey[stacks];
        for (int i = 0; i < stacks && stacks > 1; i++)
        {
            byte red = (byte)((255 / stacks) * (stacks - i));
            ColorKeys[i] = new GradientColorKey (new Color32(red, 0, 0, 255), ((float)i + 1) / (float)stacks);
            AlphaKeys[i] = new GradientAlphaKey (1.0f, ((float)i + 1) / (float)stacks);
        }

        if (stacks == 1)
        {
            ColorKeys[0] = new GradientColorKey (new Color32(255, 0, 0, 255), 1.0f);
            AlphaKeys[0] = new GradientAlphaKey (1.0f, 1.0f);
        }
        Array.Reverse(ColorKeys);
        Array.Reverse(AlphaKeys);

        this.gradient.SetKeys(ColorKeys, AlphaKeys);

        this.healthColor.color = this.gradient.Evaluate(1.0f);
        if (currentStack == 1)
            this.inlineColor.color = Color.white;
        else
            this.inlineColor.color = this.gradient.Evaluate(((float)currentStack - 1) / (float)stacks);
    }

    public void damage(int damage)
    {
        currentHealth -= damage;

        if (damage > slider.value && currentHealth - damage > 0) // carryover if
        {
            int carryover = damage - ((int) this.slider.value);
            this.slider.value -= damage;
            this.slider.value = (maxHealth / stacks) - carryover;
            currentStack--;
        }
        else
        {
            this.slider.value -= damage;
        }

        this.healthColor.color = this.gradient.Evaluate ((float)currentStack / (float)stacks); // get % and cast to float

        if (currentStack == 1)
            this.inlineColor.color = Color.white;
        else
            this.inlineColor.color = this.gradient.Evaluate(((float)currentStack - 1) / (float)stacks);
        Debug.Log((float)currentStack / (float)stacks);
    }

    public int getMaxHealth() { return this.maxHealth; }

    public int getHealth() { return this.currentHealth; }
}
