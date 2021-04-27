using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
// Clase que notifica a los observadores que ha habido un cambio
// Se definen en ScriptableObjects con una lista de SignalListeners
// 
// Esta clase debe ser instanciada como una variable en las clases
// que deban notificar algo
public class CustomSignal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();
    
    // Llamado por los objetos que deben notificar a los observadores
    // de que algo ha cambiado. El evento puede ser cualquier cosa.
    public void Notify() 
    {
        for (int x = listeners.Count - 1; x >= 0; x--) 
        {
            listeners[x].OnSignalFired();
        }
    }

    public void RegisterListener(SignalListener l) 
    {
        listeners.Add(l);
    }

    public void UnregisterListener(SignalListener l)
    {
        listeners.Remove(l);
    }
}
