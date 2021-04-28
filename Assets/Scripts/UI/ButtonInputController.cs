using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInputController : MonoBehaviour, IPointerDownHandler
{
    public CustomSignal isActive;

    // Cuando el usuario hace click en la pantalla
    public void OnPointerDown(PointerEventData ped)
    {
        isActive.Notify();
    }
}
