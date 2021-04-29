using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTransferController : RoomTransferController
{

    public CustomSignal enterSecret;
    public CustomSignal exitSecret;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("EnterSecret") && other.isTrigger)
        {
            cam.minimumPosition += cameraChangeOnRoom;
            cam.maximumPosition += cameraChangeOnRoom;
            other.transform.position += playerChangeOnRoom;
            enterSecret.Notify();
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("ExitSecret") && other.isTrigger)
        {
            cam.minimumPosition += cameraChangeOnRoom;
            cam.maximumPosition += cameraChangeOnRoom;
            other.transform.position += playerChangeOnRoom;
            exitSecret.Notify();
        }
    }
}
