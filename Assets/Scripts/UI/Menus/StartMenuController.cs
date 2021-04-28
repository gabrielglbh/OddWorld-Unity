using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MenuController
{

    public CustomSignal enterGame;

    void Start()
    {
        GetComponent<MenuController>().CreateMenu();
    }

    public void StartPlay()
    {
        GetComponent<MenuController>().StartAgain();
        enterGame.Notify();
    }
}
