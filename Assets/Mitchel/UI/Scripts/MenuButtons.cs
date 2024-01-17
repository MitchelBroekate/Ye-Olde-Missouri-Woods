using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    #region Variables
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject audioSettings;
    public GameObject quitOptions;
    public GameObject creditsMenu;
    #endregion

    #region Main Menu Buttons
    public void StartButton()
    {
        SceneManager.LoadScene("Main Game", LoadSceneMode.Single);
    }

    public void SettingsButton()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        mainMenu.SetActive(false);
        quitOptions.SetActive(true);
    }
    #endregion

    #region Quit Options Buttons
    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitBackToMenu()
    {
        quitOptions.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion

    #region Settings Menu Buttons
    public void SettingsBackToMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void AudioSettings()
    {

        audioSettings.SetActive(true);
    }
    #endregion
}
