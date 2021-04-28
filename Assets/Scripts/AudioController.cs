using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public BoolValue isAudioMuted;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if (!isAudioMuted.RuntimeValue)
        {
            sound.Play();
        }
    }

    public void StopAudio()
    {
        if (!isAudioMuted.RuntimeValue)
        {
            sound.Stop();
        }
    }

    public void EnableAudio()
    {
        if (sound.mute)
        {
            sound.mute = false;
            isAudioMuted.RuntimeValue = false;
        }
        else
        {
            sound.mute = true;
            isAudioMuted.RuntimeValue = true;
        }
    }
}
