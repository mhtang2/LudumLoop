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
        LoadLevels("Master");
        LoadLevels("SoundEffect");
        LoadLevels("Music");
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

    private void LoadLevels(string name)
    {
        float temp = PlayerPrefs.GetFloat(name + "MixerLevel");
        if (temp != 0)
        {
            Debug.Log("Test");
            audioMixer.SetFloat(name, temp);
        }
    }
}
