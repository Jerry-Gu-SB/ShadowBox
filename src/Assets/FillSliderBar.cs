using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSliderBar : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = circleSpawner.maxHealth;
        
        // removes the small dot at the end of the slider when its empty
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        
        // changes the healthbar to yellow @ 2/3 of the way and red when 1/3 health left

        float fillValue = circleSpawner.currentHealth;

        if ((fillValue <= slider.maxValue / 1.5) && (fillValue >= slider.maxValue / 3))
        {
            fillImage.color = Color.yellow;
        }

        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }

        slider.value = fillValue;
    }
}
