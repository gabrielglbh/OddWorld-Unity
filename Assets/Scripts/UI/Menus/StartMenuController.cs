using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MenuController
{

    public CustomSignal enterGame;

    void Start()
    {
        CreateMenu();
    }

    public void StartPlay()
    {
        StartAgain();
        enterGame.Notify();
    }
}
