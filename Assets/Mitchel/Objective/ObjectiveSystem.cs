using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveSystem : MonoBehaviour
{
    [Header("Enemy Area")]
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public GameObject area4;
    public GameObject area5;
    public GameObject area6;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip intro;
    public AudioClip tutorial;
    public AudioClip attack1;
    public AudioClip attack2;
    public AudioClip attack3;
    public AudioClip attack4;
    public AudioClip attack5;
    public AudioClip attack6;
    public AudioClip outro;


    [Header("Checkpoint Location")]
    public GameObject v1;
    public GameObject v2;
    public GameObject v3;
    public GameObject v4;
    public GameObject v5;

    [Header("Canvas")]
    [SerializeField]
    GameObject canvas;

    private int audioCheck;

    private void Start()
    {
        audioSource.clip = intro;
        audioSource.Play();
        canvas.transform.position = v1.transform.position;

        audioCheck = 0;
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            if(audioCheck == 0)
            {
                audioSource.clip = tutorial;
                audioSource.Play();
                audioCheck++;
            }
            if (audioCheck == 1)
            {
                audioSource.clip = attack1;
                audioSource.Play();
                audioCheck++;
            }

        }

        if(audioCheck == 2)
        {
            if (area1.transform.childCount < 1)
            {
                audioSource.clip = attack2;
                audioSource.Play();
                canvas.transform.position = v2.transform.position;
            }

            if (area2.transform.childCount < 1)
            {
                audioSource.clip = attack3;
                audioSource.Play();
                canvas.transform.position = v3.transform.position;
            }

            if (area3.transform.childCount < 1)
            {
                audioSource.clip = attack4;
                audioSource.Play();
                canvas.transform.position = v4.transform.position;
            }

            if (area4.transform.childCount < 1)
            {
                audioSource.clip = attack5;
                audioSource.Play();
                canvas.transform.position = v5.transform.position;
            }

            if (area5.transform.childCount < 1)
            {
                audioSource.clip = attack6;
                audioSource.Play();
                canvas.transform.position = v1.transform.position;
            }

            if (area6.transform.childCount < 1)
            {
                audioSource.clip = outro;
                audioSource.Play();
                canvas.SetActive(false);

                if (!audioSource.isPlaying)
                {
                    SceneManager.LoadScene("WinScene");
                }
            }
        }
    }
}
