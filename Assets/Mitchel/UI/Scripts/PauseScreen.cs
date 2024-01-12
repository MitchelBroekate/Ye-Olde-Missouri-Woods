using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    #region Variables
    private bool isPaused;

    private Vector3 pausePos;

    [SerializeField]
    private GameObject notPaused;
    [SerializeField]
    private GameObject paused;

    [SerializeField]
    private GameObject optionsPaused;
    [SerializeField]
    private GameObject settingsPaused;
    [SerializeField]
    private GameObject quitPaused;
    #endregion

    //void for pausing game/checking if paused, bringing out UI and changing player controls
    private void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;

            pausePos = notPaused.transform.position;
            paused.transform.position = pausePos;

            notPaused.SetActive(false);
            paused.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;

            notPaused.SetActive(true);
            paused.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    //void for unpausing game with UI button
    public void ResumeB()
    {
        if (isPaused)
        {
            isPaused = false;

            notPaused.SetActive(true);
            paused.SetActive(false);

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
}
