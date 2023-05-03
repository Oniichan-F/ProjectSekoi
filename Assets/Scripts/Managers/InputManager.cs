using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    private bool[] tapStates;
    private bool[] flickStates;
    public bool[] dragStates;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
            tapStates   = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false};
            flickStates = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false};
            dragStates  = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false};
        }
        else {
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        ResetState();
    }

    public void SetTapState(int id, bool state)
    {
        tapStates[id] = state;
    }

    public void SetFlickState(int id, bool state)
    {
        flickStates[id] = state;
    }

    public void SetDragState(int id, bool state)
    {
        dragStates[id] = state;
    }

    public bool GetTapState(int id)
    {
        return tapStates[id];
    }

    public bool GetFlickState(int id)
    {
        return flickStates[id];
    }

    public bool GetDragState(int id)
    {
        return dragStates[id];
    }

    public void ResetState()
    {
        for(int i = 0; i < tapStates.Length; i++) {
            tapStates[i] = false;
        }
        for(int i = 0; i < flickStates.Length; i++) {
            flickStates[i] = false;
        }
    }

}
