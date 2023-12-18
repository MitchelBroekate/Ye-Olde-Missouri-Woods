using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
