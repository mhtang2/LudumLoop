using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public Object[] myMusic; // declare this as Object array
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        playRandomMusic();
        DontDestroyOnLoad(this.gameObject);
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
