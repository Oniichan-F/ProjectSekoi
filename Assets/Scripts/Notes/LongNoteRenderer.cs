using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteRenderer : MonoBehaviour
{
    public Vector3[] positions;

    private LineRenderer lineRenderer;
    private float startWidth;
    private float endWidth;
    private int smooth;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numCornerVertices = smooth;
    }

    private void Update()
    {
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    public void setOptions(float sw, float ew, int sm)
    {
        startWidth = sw;
        endWidth   = ew;
        smooth     = sm;
    }
}
