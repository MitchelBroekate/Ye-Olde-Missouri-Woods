using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    #region Variables
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject videoSettings;
    public GameObject audioSettings;
    public GameObject quitOptions;
    #endregion

    #region Main Menu Buttons
    public void StartButton()
    {
        SceneManager.LoadScene("Main Game");
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

    public void VideoSettings()
    {
        if(audioSettings.activeInHierarchy == true)
        {
            audioSettings.SetActive(false);
        }

        videoSettings.SetActive(true);
    }

    public void AudioSettings()
    {
        if(videoSettings.activeInHierarchy == true)
        {
            videoSettings.SetActive(false);
        }

        audioSettings.SetActive(true);
    }
    #endregion
}
