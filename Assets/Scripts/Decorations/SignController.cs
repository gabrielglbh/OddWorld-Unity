using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Aplicado a las señales del juego
public class SignController : MonoBehaviour
{
    // Dialog box para controlar su activamiento
    public GameObject dialogBox;
    // Text Object para definir el texto del dialogo 
    // con el string dialog
    public Text dialogText;
    public string dialog;
    public bool isPlayerInRange;
    public bool isInteractable;
    public int fontSize;

    void Update()
    {
        if (isInteractable)
        {
            if (Input.GetButtonDown("interact") && isPlayerInRange)
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
