using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Clase que debe ser importada en el GameObject que necesita saber
// de una determinada CustomSignal en el editor de Unity
//
// UnityEvent se debe añadir en el editor con: Runtime Only > GameObject
// Y seleccionar el script del GameObject y la función que se quiera ejecutar
// cuando CustomSignal se notique
public class SignalListener : MonoBehaviour
{
    // Evento personalizado el cual se está observando
    public CustomSignal signal;
    // Evento de Unity el cual nos permite ejecutar una función 
    // de cualquier tipo cuando el CustomSignal esté notificando
    public UnityEvent signalEvent;

    public void OnSignalFired() 
    {
        signalEvent.Invoke();
    }

    private void OnEnable() {
        signal.RegisterListener(this);
    }

    private void OnDisable() {
        signal.UnregisterListener(this);
    }
}
