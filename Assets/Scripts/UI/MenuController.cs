using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public Text data;
    public Text elapsedTime;
    public FloatValue currentPoints;
    public GameObject player;
    public FloatValue containers;
    public FloatValue playerHealth;
    public CustomSignal health;
    private CameraMovement cam;

    void Start()
    {
        cam = GetComponent<CameraMovement>();
    }

    public void CreateMenu()
    {
        menu.SetActive(true);
        data.text = "Tiempo en la Prueba: " + elapsedTime.text + " segundos " +
                    "\nPuntos Totales: " + currentPoints.RuntimeValue;
    }

    public void StartAgain()
    {
        menu.SetActive(false);
        if (this.gameObject.CompareTag("GameOverMenu"))
        {
            player.SetActive(true);
            containers.RuntimeValue = 3;
            playerHealth.RuntimeValue = 6;
            health.Notify();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
