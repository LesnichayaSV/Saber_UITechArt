using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{
    public Image image;
    public Slider slider;

    public Color startColor = Color.white;
    public Color targetColor = Color.black;

    
    void Start()
    {
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float sliderValue = slider.value;
        image.color = Color.Lerp(startColor, targetColor, sliderValue / 1f);
    }
}
