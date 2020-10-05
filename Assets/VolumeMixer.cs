using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string mixerName;

    public void Awake()
    {
        float outValue;
        audioMixer.GetFloat(mixerName, out outValue);
        GetComponent<Slider>().SetValueWithoutNotify(Mathf.Pow(10, outValue/20));
    }

    public void SetLevel (float sliderValue)
    {
        audioMixer.SetFloat(mixerName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(mixerName+"MixerLevel", Mathf.Log10(sliderValue) * 20);
    }
}
