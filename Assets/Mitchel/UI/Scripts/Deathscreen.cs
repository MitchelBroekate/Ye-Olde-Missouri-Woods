using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    string curScene;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene().name;
    }

    public void Restart()
    {

        SceneManager.LoadScene(curScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
