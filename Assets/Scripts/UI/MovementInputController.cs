using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Extraído de: https://www.youtube.com/watch?v=2GQe1cvHx9U
//
// Se ha polarizado para el uso de los ScriptableObjects para pasar
// la dirección de InputController a PlayerController
public class MovementInputController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    // Distancia a la que podemos arrastrar el elemento joystick fuera de su posición
    private float visualDistance = 40f;
    private Image container;
    private Image joystick;
    public InputDirection direction;

    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        container = images[0];
        joystick = images[1];
    }

    // Cuando el usuario sostiene el dedo en la pantalla
    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;
        // Verifico si mi dedo está dentro del container
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            container.rectTransform, ped.position, ped.pressEventCamera, out position))
        {
            position.x /= container.rectTransform.sizeDelta.x;
            position.y /= container.rectTransform.sizeDelta.y;

            Vector2 pivot = container.rectTransform.pivot;
            position.x += pivot.x - 0.5f;
            position.y += pivot.y - 0.5f;

            float x = Mathf.Clamp(position.x, -1, 1);
            float y = Mathf.Clamp(position.y, -1, 1);

            direction.RuntimeValue = new Vector3(x, y, 0).normalized;

            // Mueve el joystick hacia la dirección
            joystick.rectTransform.anchoredPosition = new Vector3(
                direction.RuntimeValue.x * visualDistance, direction.RuntimeValue.y * visualDistance);
        }
    }

    // Cuando el usuario hace click en la pantalla
    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    // Cuando el usuario levanta el dedo de la pantalla
    public void OnPointerUp(PointerEventData ped)
    {
        // Hace reset del joystick y la dirección
        direction.RuntimeValue = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
