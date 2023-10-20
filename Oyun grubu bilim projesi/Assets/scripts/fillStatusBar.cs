using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillStatusBar : MonoBehaviour
{
    public hareket playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;

        if (fillValue<=slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        if(fillValue > slider.maxValue / 3 && fillValue < slider.maxValue / 1.5)
        {
            fillImage.color = Color.yellow;
        }
        if (fillValue >= slider.maxValue / 1.5)
        {
            fillImage.color = Color.red;
        }

       
        slider.value = fillValue;

    }

}

