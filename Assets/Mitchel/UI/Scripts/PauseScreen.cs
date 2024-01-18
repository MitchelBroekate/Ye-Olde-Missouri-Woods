using Oculus.Interaction;
using Oculus.Interaction.Locomotion;
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
    private GameObject player;

    [SerializeField]
    private GameObject optionsPaused;
    [SerializeField]
    private GameObject settingsPaused;
    [SerializeField]
    private GameObject quitPaused;

    [SerializeField]
    private GameObject locomotion;

    [SerializeField]
    private GameObject pointerLeft;
    [SerializeField]
    private GameObject pointerRight;

    [SerializeField]
    private GameObject uI;
    [SerializeField]
    private GameObject uIOverlay;

    [SerializeField]
    private GameObject rayLeft;
    [SerializeField]
    private GameObject rayRight;
    #endregion

    //void for pausing game/checking if paused, bringing out UI and changing player controls
    public void Pause()
    {
       PlayerLocomotor locomoter = locomotion.GetComponent<PlayerLocomotor>();
       
        
        if (!isPaused)
        {
            transform.position = player.transform.forward;

            locomoter.enableWalk = false;

            pointerLeft.SetActive(false);
            pointerRight.SetActive(false);

            rayLeft.SetActive(true);
            rayRight.SetActive(true);

            uI.SetActive(true);
            uIOverlay.SetActive(false);

            isPaused = true;

            Time.timeScale = 0f;
        }
        else
        {
            locomoter.enableWalk = true;

            pointerLeft.SetActive(true);
            pointerRight.SetActive(true);

            rayLeft.SetActive(false);
            rayRight.SetActive(false);

            uI.SetActive(false);
            uIOverlay.SetActive(true);

            isPaused = false;

            Time.timeScale = 1f;
        }
    }

    //void for unpausing game with UI button
    public void ResumeB()
    {
        if (isPaused)
        {
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
}
