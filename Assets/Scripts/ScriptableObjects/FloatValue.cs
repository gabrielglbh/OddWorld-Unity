using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
// Clase que sirve para definir una variable global al proyecto
// en este caso:
//      - la vida de los enemigos
//      - el número de corazones del jugador
//      - la vida del jugador
// 
// initialValue, al ser un ScriptableObject, es ajeno a la escena.
// Por lo tanto, al ejecutarse el juego y hacer que el valor de initialValue
// cambie, el valor no vuelve a ponerse como antes de ejecutarse el juego.
// Para evitar ejecutar el juego con valores erróneos, la calse se extiende de 
// ISerializationCallbackReceiver. De esta manera, se proporciona un RuntimeValue
// que será igual siempre al initialValue, quedando initialValue inmodificable.
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;
    public void OnAfterDeserialize() {
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize() {}
}
