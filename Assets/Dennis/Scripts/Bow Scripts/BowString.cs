using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowString : MonoBehaviour
{
    [SerializeField]
    private Transform endpointTop, endpointBottom;

    private LineRenderer lineRenderer;

    #region Start + Awake
    private void Start()
    {
        CreateString(null);
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    #endregion

    #region Bowstring Creation
    public void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = endpointTop.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }
        linePoints[^1] = endpointBottom.localPosition;

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }
    #endregion
}
