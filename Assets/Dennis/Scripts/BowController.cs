using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private BowString bowStringRenderer;

    private PointableUnityEventWrapper interactable;

    [SerializeField]
    private Transform midPointGrabObject;

    private Transform interactor;

    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<PointableUnityEventWrapper>();
    }

    private void Start()
    {

    }

    public void ResetBowString()
    {
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);

    }

    public void PrepareBowString()
    {

    }
}
