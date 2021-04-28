using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MenuController
{
    public void StartPlay()
    {
        GetComponent<MenuController>().StartAgain();
    }
}
