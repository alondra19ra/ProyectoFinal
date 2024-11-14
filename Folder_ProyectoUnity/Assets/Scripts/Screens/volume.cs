using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        AudioListener.volume = slider.value;
        CheckIfMute();
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Volume", sliderValue);
        AudioListener.volume = slider.value;
        CheckIfMute();
    }

    public void CheckIfMute()
    {
        if(sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
