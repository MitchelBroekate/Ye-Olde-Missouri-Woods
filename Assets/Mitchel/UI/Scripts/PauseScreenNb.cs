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

    public GameObject buttonQuit1;
    public GameObject buttonQuit2;

    public GameObject buttonBack1;
    public GameObject buttonBack2;

    public GameObject buttonSettings;

    public GameObject buttonResume;

    public GameObject masterUp;
    public GameObject masterDown;
    public GameObject musicUp;
    public GameObject musicDown;
    public GameObject sfxUp;
    public GameObject sfxDown;
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
            buttonResume.SetActive(false);
            StartCoroutine(Wait(1f));
            buttonResume.SetActive(true);
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
            buttonSettings.SetActive(false);
            StartCoroutine(Wait(1f));
            buttonSettings.SetActive(true);
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
                buttonQuit1.SetActive(false);
                StartCoroutine(Wait(1f));
                buttonQuit1.SetActive(false);

                Application.Quit();
            }
            else
            {

                buttonQuit2.SetActive(false);
                StartCoroutine(Wait(1f));
                buttonQuit2.SetActive(false);
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
                buttonBack1.SetActive(false);
                StartCoroutine(Wait(1f));
                buttonBack1.SetActive(true);
                settingsPaused.SetActive(false);
                optionsPaused.SetActive(true);
            }
            else
            {
                buttonBack2.SetActive(false);
                StartCoroutine(Wait(1f));
                buttonBack2.SetActive(true);
                quitPaused.SetActive(false);
                optionsPaused.SetActive(true);
            }
        }
    }

    public void VolumeMasterUp()
    {
        masterUp.SetActive(false);
        StartCoroutine(Wait(1f));
        masterUp.SetActive(true);

        sliderMaster.value += 0.1f;
    }

    public void VolumeMasterDown()
    {
        masterDown.SetActive(false);
        StartCoroutine(Wait(1f));
        masterDown.SetActive(true);

        sliderMaster.value -= 0.1f;
    }

    public void VolumeSFXUp()
    {
        sfxUp.SetActive(false);
        StartCoroutine(Wait(1f));
        sfxUp.SetActive(true);

        sliderSFX.value += 0.1f;
    }

    public void VolumeSFXDown()
    {

        sfxDown.SetActive(false);
        StartCoroutine(Wait(1f));
        sfxDown.SetActive(true);

        sliderSFX.value -= 0.1f;
    }

    public void VolumeMusicUp()
    {

        musicUp.SetActive(false);
        StartCoroutine(Wait(1f));
        musicUp.SetActive(true);

        sliderMusic.value += 0.1f;
    }

    public void VolumeMusicDown()
    {

        musicDown.SetActive(false);
        StartCoroutine(Wait(1f));
        musicDown.SetActive(true);

        sliderMusic.value -= 0.1f;
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}