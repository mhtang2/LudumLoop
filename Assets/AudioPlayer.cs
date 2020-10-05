using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public static bool exists = false;
    public Object[] myMusic; // declare this as Object array
    public AudioMixer audioMixer;
    AudioSource audio;

    void Awake()
    {
        if (exists)
        {
            Destroy(gameObject);
        }
        exists = true;
        audio = GetComponent<AudioSource>();
        playRandomMusic();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        float temp = PlayerPrefs.GetFloat("MasterMixerLevel");
        if (temp != 0)
        {
            Debug.Log("Test");
            audioMixer.SetFloat("Master", temp);
        }
        if (audio != null)
        {
            audio.Play();
        }
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
