using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] LightPanel lightPanel;
    

    public void onTap()
    {
        lightPanel.Flash();
    }
}
