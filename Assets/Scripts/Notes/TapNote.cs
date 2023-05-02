using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNote : Note
{
    private void Update()
    {
        if(RhythmGameManager.instance.tmp) {
            UpdatePosition();
            UpdateTime();
        }
    }

    public void setSize()
    {
        transform.localScale = new Vector3(transform.localScale.x*size, transform.localScale.y, transform.localScale.z);
    }
}
