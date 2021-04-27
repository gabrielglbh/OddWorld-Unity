using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    // Determinados en el propio Unity posicionando la cámara al gusto
    public Vector2 maximumPosition;
    public Vector2 minimumPosition;

    void LateUpdate()
    {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Si la cámara se sale de los max y min establecidos, se hace un Clamp para que no se salga de ellos
            targetPosition.x = Mathf.Clamp(targetPosition.x, minimumPosition.x, maximumPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minimumPosition.y, maximumPosition.y);

            // Mueve la cámara desde transform.position a targetPosition
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
