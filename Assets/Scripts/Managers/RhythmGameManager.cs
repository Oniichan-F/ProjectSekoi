using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public static RhythmGameManager instance = null;

    public bool isDebugMode;
    public bool isAutoMode;

    public int songID;
    public string songDisplayName;
    public string songFileName;
    public string chartFileName;
    
    public bool isGameActive;
    public bool isChartGenerated;

    public float baseNoteSpeed;

    public bool tmp;

    private void Awake()
    {
        if(instance == null) {
            Application.targetFrameRate = 60;
            instance = this;
            isGameActive = true;
            isChartGenerated = false;
            lookupSongTable();
        }
        else {
            Destroy(this.gameObject);
        }
    }

    private void lookupSongTable()
    {
        switch(songID) {
            case 0:
                songDisplayName = "Test : BPM = 60";
                songFileName    = "test00";
                chartFileName   = "test00";
                break;
            default:
                songDisplayName = "empty";
                songFileName    = "empty";
                chartFileName   = "empty";
                break;
        }
    }

}
