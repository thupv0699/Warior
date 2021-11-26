using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] Gradient gradient;

    [SerializeField] Image fill;

    [SerializeField] GameObject player;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;

        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void setHealth(int health)
    {
        slider.value= health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
