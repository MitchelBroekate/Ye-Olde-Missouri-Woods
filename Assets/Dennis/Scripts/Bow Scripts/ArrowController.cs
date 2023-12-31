using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField]
    private GameObject midPointVisual;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private GameObject arrowSpawnPoint;
    [SerializeField]
    private AudioSource bowReleaseAudioSource;

    [SerializeField]
    private float arrowMaxSpeed = 10f;

    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        bowReleaseAudioSource.Play();

        if (strength >= 0.75f)
        {
            midPointVisual.SetActive(false);

            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = arrowSpawnPoint.transform.position;
            arrow.transform.rotation = midPointVisual.transform.rotation;
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        }
    }
}
