using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual;

    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        midPointVisual.SetActive(false);
        Debug.Log($"Bow Strength is {strength}");
    }
}
