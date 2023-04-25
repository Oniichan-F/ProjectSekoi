using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] LightPanel lightPanel;
    

    public void onTap()
    {
        lightPanel.Flash();
        Debug.Log("tap");
    }

    public void onFlick()
    {
        Debug.Log("flick");
    }

    public void onEnter()
    {
        lightPanel.Flash();
        Debug.Log("enter");
    }

    public void onExit()
    {
        Debug.Log("exit");
    }
}
