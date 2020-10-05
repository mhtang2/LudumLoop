using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMixer : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetLevel (float sliderValue)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterMixerLevel", Mathf.Log10(sliderValue) * 20);
    }
}
