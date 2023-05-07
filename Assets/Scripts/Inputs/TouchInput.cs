using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] LightPanel lightPanel;
    [SerializeField] InputManager inputManager;
    [SerializeField] int id;

    public void onTap()
    {
        lightPanel.Flash();
        inputManager.SetTapState(id, true);
    }

    public void onFlick()
    {
        inputManager.SetFlickState(id, true);
    }

    public void onEnter()
    {
        lightPanel.Flash();
        inputManager.SetDragState(id, true);
    }

    public void onExit()
    {
        inputManager.SetDragState(id, false);
    }
}
