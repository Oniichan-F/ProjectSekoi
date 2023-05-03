using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool[] tapStates = {false, false, false, false, false, false, false, false, false, false, false, false};
    private bool[] flickStates = {false, false, false, false, false, false, false, false, false, false, false, false};
    private bool[] dragStates = {false, false, false, false, false, false, false, false, false, false, false, false};

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
