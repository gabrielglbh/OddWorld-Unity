using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuController : MenuController
{
    public Text data;
    public Text elapsedTime;
    public Text points;
    public FloatValue currentPoints;
    public GameObject player;
    public FloatValue containers;
    public FloatValue playerHealth;
    public CustomSignal health;

    public void Create()
    {
        CreateMenu();
        data.text = "Tiempo en la Prueba: " + elapsedTime.text + " segundos " +
                    "\nPuntos Totales: " + points.text;
    }

    public void Restart()
    {
        player.SetActive(true);
        containers.RuntimeValue = 5;
        playerHealth.RuntimeValue = 10;
        currentPoints.RuntimeValue = 0;
        points.text = "000";
        health.Notify();
        StartAgain();
    }
}
