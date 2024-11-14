using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class glow : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelGlow;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("glow", 0.5f);
        panelGlow.color = new Color(panelGlow.color.r, panelGlow.color.g, panelGlow.color.b, slider.value);
    }

    private void Update()
    {
        
    }

    public void ChangeSider (float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("glow", sliderValue);
        panelGlow.color = new Color(panelGlow.color.r, panelGlow.color.g, panelGlow.color.b, slider.value);
    }
}
