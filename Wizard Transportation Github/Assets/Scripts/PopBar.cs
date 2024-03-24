using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxPopularity(int popularity)
    {
        slider.maxValue = popularity;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetPopularity(int popularity)
    {
        slider.value = popularity;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
