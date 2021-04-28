using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject controls;
    public Text data;
    public Text elapsedTime;
    public Text points; 
    public FloatValue currentPoints;
    public GameObject player;
    public FloatValue containers;
    public FloatValue playerHealth;
    public CustomSignal health;

    public void CreateMenu()
    {
        menu.SetActive(true);
        controls.SetActive(false);
        data.text = "Tiempo en la Prueba: " + elapsedTime.text + " segundos " +
                    "\nPuntos Totales: " + currentPoints.RuntimeValue;
    }

    // Se hace reset de todos los parámetros
    public void StartAgain()
    {
        menu.SetActive(false);
        controls.SetActive(true);
        if (this.gameObject.CompareTag("GameOverMenu"))
        {
            player.SetActive(true);
            containers.RuntimeValue = 5;
            playerHealth.RuntimeValue = 10;
            points.text = "000";
            health.Notify();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
