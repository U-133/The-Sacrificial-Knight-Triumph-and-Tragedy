using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public TextMeshProUGUI volAmount;
    public Slider volumeSlider;

    public void SetAudio()
    {
        float sliderValue = volumeSlider.value;
        AudioListener.volume = sliderValue;
        volAmount.text = ((int)(sliderValue * 100)).ToString();
    }
}