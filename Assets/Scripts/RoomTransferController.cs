using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoomTransferController : MonoBehaviour
{
    public Vector2 cameraChangeOnRoom;
    public Vector3 playerChangeOnRoom;  
    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Cuando el jugador entra en el collider de RoomTransferTrigger
    // se mueve la cámara a la siguiente sala y se actualizan
    // los minimos y máximos de la cámara
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("TrialEnter") && other.isTrigger) 
        {
            cam.minimumPosition += cameraChangeOnRoom;
            cam.maximumPosition += cameraChangeOnRoom;
            other.transform.position += playerChangeOnRoom;
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("TrialExit") && other.isTrigger) 
        {
            cam.minimumPosition += cameraChangeOnRoom;
            cam.maximumPosition += cameraChangeOnRoom;
            other.transform.position += playerChangeOnRoom;
        }
    }
}
