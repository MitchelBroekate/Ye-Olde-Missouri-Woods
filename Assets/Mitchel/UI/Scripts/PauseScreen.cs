using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private bool isPaused;

    private Vector3 pausePos;

    [SerializeField]
    private GameObject notPaused;
    [SerializeField]
    private GameObject paused;

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
}
