using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StopAudio()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void EnableAudio()
    {

    }

    public void DiableAudio()
    {
        
    }
}
