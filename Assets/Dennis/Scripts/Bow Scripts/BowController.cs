using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowController : MonoBehaviour
{
    private PointableUnityEventWrapper interactable;

    [Header("Attributes")]
    [SerializeField]
    private BowString bowStringRenderer;
    [SerializeField]
    private Transform midPointGrabObject;
    [SerializeField]
    private Transform midPointVisualObject;
    [SerializeField]
    private GameObject midPointVisual;
    [SerializeField]
    private Transform midPointParent;
    [SerializeField]
    private Transform handObject;
    [SerializeField]
    private float bowStringStretchLimit = 0.3f;

    private Transform interactor;

    private float strength, previousStrength;

    [SerializeField]
    private float stringSoundThreshold = 0.001f;

    [SerializeField]
    private AudioSource stringPulledAudioSource;

    public UnityEvent onBowPulled;
    public UnityEvent<float> onBowReleased;

    #region Awake + Update
    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<PointableUnityEventWrapper>();
    }

    private void Update()
    {
        if (interactor != null)
        {
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);

            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);

            previousStrength = strength;

            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackToLimit(midPointLocalZAbs, midPointLocalSpace);

            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);


            bowStringRenderer.CreateString(midPointVisualObject.position);
        }
    }
    #endregion

    #region Bowstring
    public void ResetBowString()
    {
        onBowReleased?.Invoke(strength);
        strength = 0;
        previousStrength = 0;
        stringPulledAudioSource.pitch = 1;
        stringPulledAudioSource.Stop();

        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;

        midPointVisual.SetActive(false);
        bowStringRenderer.CreateString(null);

    }

    public void PrepareBowString()
    {
        onBowPulled?.Invoke();

        interactor = handObject.transform;
    }


    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            if (stringPulledAudioSource.isPlaying == false && strength <= 0.01f)
            {
                stringPulledAudioSource.Play();
            }

            strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);

            PlayStringPullingSound();
        }
    }

    private void PlayStringPullingSound()
    {
        if (Mathf.Abs(strength - previousStrength) > stringSoundThreshold)
        {
            if (strength < previousStrength)
            {
                stringPulledAudioSource.pitch = -1;
            }
            else
            {
                stringPulledAudioSource.pitch = 1;
            }
            stringPulledAudioSource.UnPause();
        }
        else
        {
            stringPulledAudioSource.Pause();
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            stringPulledAudioSource.Pause();
            strength = 1;
            midPointVisualObject.localPosition = new Vector3(0, 0, -bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            stringPulledAudioSource.pitch = 1;
            stringPulledAudioSource.Stop();
            strength = 0;
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
    #endregion
}
