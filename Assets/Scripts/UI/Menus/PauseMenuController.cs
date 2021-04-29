using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MenuController
{

    public CustomSignal enterGame;

    public void CreatePauseMenu()
    {
        CreateMenu();
    }

    public void RemovePauseMenu()
    {
        RemoveMenu();
    }
}
