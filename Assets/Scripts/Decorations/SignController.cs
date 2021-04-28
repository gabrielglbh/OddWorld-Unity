using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Aplicado a las señales del juego
public class SignController : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    public bool isPlayerInRange;
    public bool isInteractable;
    public int fontSize;

    // SOLO CREADO PARA LOS OBJETOS INTERACTUABLES: isInteractable = true
    // A la espera de ser ejecutado mediante la notificación de isInteractSignal
    // llamada desde ButtonInputController
    public void ShowDialog()
    {
        if (isInteractable && isPlayerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                SetDialog();
            }
        }
    }

    private void SetDialog()
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        dialogText.fontSize = fontSize;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))  
        {
            isPlayerInRange = true;
            if (!isInteractable)
            {
                SetDialog();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            isPlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
