using Oculus.Interaction;
using Oculus.Interaction.Locomotion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenNB : MonoBehaviour
{
    #region Variables
    private bool isPaused;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject optionsPaused;
    [SerializeField]
    private GameObject settingsPaused;
    [SerializeField]
    private GameObject quitPaused;
    [SerializeField]
    private GameObject uiOverlay;
    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private Slider sliderMaster;
    [SerializeField]
    private Slider sliderMusic;
    [SerializeField]
    private Slider sliderSFX;
    #endregion

    //void for pausing game/checking if paused, bringing out UI and changing player controls
    public void Pause()
    {
        if (!isPaused)
        {
            uiOverlay.SetActive(false);
            ui.SetActive(true);

            isPaused = true;

            Time.timeScale = 0f;
        }
        else
        {
            uiOverlay.SetActive(true);
            ui.SetActive(false);

            isPaused = false;

            Time.timeScale = 1f;
        }
    }

    //void for unpausing game with UI button
    public void ResumeB()
    {
        if (isPaused)
        {
            uiOverlay.SetActive(true);
            ui.SetActive(false);

            isPaused = false;

            Time.timeScale = 1f;
        }
    }

    //void for changing UI window to settings
    public void SettingsB()
    {
        if (isPaused)
        {
            optionsPaused.SetActive(false);
            settingsPaused.SetActive(true);
        }

    }

    //void for quiting the application or opening the quit conformation screen
    public void QuitB()
    {
        if (isPaused)
        {


            if (quitPaused.activeInHierarchy == true)
            {
                Application.Quit();
            }
            else
            {
                optionsPaused.SetActive(false);
                quitPaused.SetActive(true);
            }
        }
    }

    // void for going back to the main pause screen
    public void BackB()
    {
        if (isPaused)
        {


            if (settingsPaused.activeInHierarchy == true)
            {
                settingsPaused.SetActive(false);
                optionsPaused.SetActive(true);
            }
            else
            {
                quitPaused.SetActive(false);
                optionsPaused.SetActive(true);
            }
        }
    }

    public void VolumeMasterUp()
    {
        sliderMaster.value += 0.1f;
    }

    public void VolumeMasterDown()
    {
        sliderMaster.value -= 0.1f;
    }

    public void VolumeSFXUp()
    {
        sliderSFX.value += 0.1f;

    }

    public void VolumeSFXDown()
    {
        sliderSFX.value -= 0.1f;
    }

    public void VolumeMusicUp()
    {
        sliderMusic.value += 0.1f;
    }

    public void VolumeMusicDown()
    {
        sliderMusic.value -= 0.1f;
    }
}