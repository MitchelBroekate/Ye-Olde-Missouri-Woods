using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject quitOptions;
    public void PlayButton()
    {
        
    }

    public void SettingsButton()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        mainMenu.SetActive(false);
        quitOptions.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsBackToMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitBackToMenu()
    {
        quitOptions.SetActive(false);
        mainMenu.SetActive(true);
    }

}
