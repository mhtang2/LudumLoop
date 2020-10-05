using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void Awake()
    {
        float outValue;
        audioMixer.GetFloat("Master", out outValue);
        GetComponent<Slider>().SetValueWithoutNotify(Mathf.Pow(10, outValue/20));
    }

    public void SetLevel (float sliderValue)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterMixerLevel", Mathf.Log10(sliderValue) * 20);
    }
}
