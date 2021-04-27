using UnityEngine;
using System.Collections;

public class HeartContainerController : MonoBehaviour
{
    public CustomSignal healthGained;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Heart") && other.isTrigger)
        {
            this.gameObject.SetActive(false);
            healthGained.Notify();
        }
    }
}
