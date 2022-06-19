using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    public circleSpawner circleSpawner;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();   
        slider.maxValue = circleSpawner.interval;
    }

    // Update is called once per frame
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

        slider.value = circleSpawner.timer;

    }
}
