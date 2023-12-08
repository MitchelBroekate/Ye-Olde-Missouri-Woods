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
    private Transform midPointParent;
    [SerializeField]
    private Transform handObject;
    [SerializeField]
    private float bowStringStretchLimit = 0.3f;

    private Transform interactor;

    private float strength;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> onBowReleased;

    #region Awake + Update
    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<PointableUnityEventWrapper>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (interactor != null)
        {
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);

            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);

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

        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);

    }

    public void PrepareBowString()
    {
        OnBowPulled?.Invoke();

        interactor = handObject.transform;
    }


    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);
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
            strength = 1;

            midPointVisualObject.localPosition = new Vector3(0, 0, -bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            strength = 0;

            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
    #endregion
}
