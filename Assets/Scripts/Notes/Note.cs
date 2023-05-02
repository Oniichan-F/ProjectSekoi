using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int id {get; set;}
    public int group {get; set;}
    public int[] lanes {get; set;}
    public int size;
    public float time {get; set;}
    public float speed {get; set;}
    public bool isTouchable {get; set;}

    private Renderer rend;

    public void Init(int id, int group, int[] lanes)
    {
        this.id    = id;
        this.group = group;
        this.lanes  = lanes;
        this.isTouchable = false;

        this.size  = lanes.Length;
        this.speed = RhythmGameManager.instance.baseNoteSpeed;
        rend = GetComponent<Renderer>();
        ChangeVisibility(true);
    }

    protected void UpdateTime()
    {
        time -= Time.deltaTime;
    }

    protected void UpdatePosition()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }

    protected void ChangeVisibility(bool isVisible)
    {
        if(isVisible) {
            rend.enabled = true; 
        }
        else {
            rend.enabled = false;
        }
    }
}
