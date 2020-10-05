using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public Object[] myMusic; // declare this as Object array
    public AudioMixer audioMixer;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        playRandomMusic();
        DontDestroyOnLoad(this.gameObject);
        float temp = PlayerPrefs.GetFloat("MasterMixerLevel");
        if (temp != 0)
        {
            audioMixer.SetFloat("Master", temp);
        }
    }

    void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
            playRandomMusic();
    }

    void playRandomMusic()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio.Play();
    }
}
