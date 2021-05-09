using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        sound.Play();
    }

    public void StopAudio()
    {
        sound.Stop();
    }
}
