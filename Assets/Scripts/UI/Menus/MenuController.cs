using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject controls;

    public void CreateMenu()
    {
        menu.SetActive(true);
        controls.SetActive(false);
    }

    public void StartAgain()
    {
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
