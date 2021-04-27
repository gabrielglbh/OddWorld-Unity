using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
// Clase que sirve para definir una variable global al proyecto
// en este caso:
//      - si el jugador está en el trial o no
//      - si el juego ha terminado porque ha muerto el jugador
// Assets > ScriptableObjects > isInTrial
//
// initialValue, al ser un ScriptableObject, es ajeno a la escena.
// Por lo tanto, al ejecutarse el juego y hacer que el valor de initialValue
// cambie, el valor no vuelve a ponerse como antes de ejecutarse el juego.
// Para evitar ejecutar el juego con valores erróneos, la calse se extiende de 
// ISerializationCallbackReceiver. De esta manera, se proporciona un RuntimeValue
// que será igual siempre al initialValue, quedando initialValue inmodificable.
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;

    [HideInInspector]
    public bool RuntimeValue;
    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize() { }
}
