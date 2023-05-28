using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public HeadNote headNote;
    public List<RelayNote> relayNotes;
    public LongNoteRenderer longNoteRenderer;

    public int state; // 0:default, 1:hold, 2:lost

    private int relayCount;
    private float startWidth;
    private float endWidth;
    private int smooth;

    private void Start()
    {
        state = 0;
        relayCount = relayNotes.Count;
        longNoteRenderer = GetComponentInChildren<LongNoteRenderer>();
        longNoteRenderer.positions = getPositions();
        longNoteRenderer.setOptions(startWidth, endWidth, smooth);
    }

    private void Update()
    {
        longNoteRenderer.positions = getPositions();
        longNoteRenderer.setOptions(startWidth, endWidth, smooth); 
    }

    private Vector3[] getPositions()
    {
        Vector3[] positions = new Vector3[relayCount+3];
        positions[0] = headNote.transform.position + new Vector3(0f, 0f, -0.3f);
        positions[1] = headNote.transform.position + new Vector3(0f, 0f, -0.2f);
        for(int i = 0; i < relayCount-1; i++) {
            positions[i+2] = relayNotes[i].transform.position;
        }
        positions[relayCount+1] = relayNotes[relayCount-1].transform.position + new Vector3(0f, 0f, -0.3f);
        positions[relayCount+2] = relayNotes[relayCount-1].transform.position + new Vector3(0f, 0f, -0.2f);
        
        return positions;
    }

    public void setOptions(float sw, float ew, int sm)
    {
        startWidth = sw;
        endWidth   = ew;
        smooth     = sm;
    }

    public void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
