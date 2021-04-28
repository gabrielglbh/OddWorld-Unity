using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MenuController
{

    public CustomSignal enterGame;

    public void CreatePauseMenu()
    {
        GetComponent<MenuController>().CreateMenu();
    }

    public void ContinuePlaying()
    {
        GetComponent<MenuController>().StartAgain();
    }
}
