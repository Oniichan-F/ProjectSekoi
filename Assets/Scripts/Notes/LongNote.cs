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
        Vector3[] positions = new Vector3[relayCount+1];
        positions[0] = headNote.transform.position;
        for(int i = 0; i < relayCount; i++) {
            positions[i+1] = relayNotes[i].transform.position;
        }
        
        return positions;
    }

    public void setOptions(float sw, float ew, int sm)
    {
        startWidth = sw;
        endWidth   = ew;
        smooth     = sm;
    }
}
