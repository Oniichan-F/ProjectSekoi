using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteRenderer : MonoBehaviour
{
    public Vector3[] positions;

    private LineRenderer lineRenderer;
    private Renderer rend;

    private float startWidth;
    private float endWidth;
    private int smooth;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numCornerVertices = smooth;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth   = endWidth;

        rend = GetComponent<Renderer>();
        ChangeColor(0);
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

    public void ChangeColor(int state)
    {
        if(state == 0) {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        }
        else if(state == 1) {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        }
        else if(state == 2) {
            rend.material.color = new Color(0.2f, 0.2f, 0.2f, 0.3f);
        }
    }
}
