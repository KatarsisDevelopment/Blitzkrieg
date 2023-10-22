using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] AudioClip;
    AudioSource AudioSource;
    int currentAudioNumber;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!AudioSource.isPlaying)
        {
            AudioSource.clip = AudioClip[currentAudioNumber];
            AudioSource.Play();
            currentAudioNumber = (currentAudioNumber + 1) % AudioClip.Length;
        }

    }
}
