using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SongTable songTable;

    public static GameManager gameManager = null;

    public bool isDebugMode = true;

    // playing song info
    public int songID;
    public string songDisplayName;
    public string songSourceName;
    public string songChartName;
    public string composerName;
    public string charterName;

    // game play
    public int difficulty; // 0:easy, 1:hard
    public bool isPaused;
    public bool isChartGenerated;


    private void Awake()
    {
        if(gameManager == null) {
            Application.targetFrameRate = 60;
            gameManager = this;

            songID           = 0;
            difficulty       = 0;
            isPaused         = false;
            isChartGenerated = false;

            songTable.SetSongInfoFromID(songID);
        }
        else {
            Destroy(this.gameObject);
        }
    }
}
