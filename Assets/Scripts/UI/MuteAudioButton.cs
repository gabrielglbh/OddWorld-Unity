using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudioButton : MonoBehaviour
{
    public Text muteAudio;
    public BoolValue isAudioMuted;

    void Update()
    {
        if (isAudioMuted.RuntimeValue)
        {
            muteAudio.text = "Activar Audio";
        }
        else
        {
            muteAudio.text = "Silenciar Audio";
        }
    }
}
