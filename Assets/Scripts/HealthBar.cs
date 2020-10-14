﻿using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public void SetMaxHealth(int _health){
        slider.maxValue = _health;
        slider.value = _health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int _health){
        slider.value = _health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
