using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTable : MonoBehaviour
{
    [SerializeField] private string[] songDisplayNames;
    [SerializeField] private string[] songSourceNames;
    [SerializeField] private string[] songChartnames;
    [SerializeField] private string[] composerNames;
    [SerializeField] private string[] charterNames;
    [SerializeField] private int[] levelEasy;
    [SerializeField] private int[] levelHard;


    public int maxID;

    private void Start()
    {
        maxID = GetMaxID();
    }

    public void SetSongInfoFromID(int id)
    {
        GameManager.gameManager.songDisplayName = songDisplayNames[id];
        GameManager.gameManager.songSourceName  = songSourceNames[id];
        GameManager.gameManager.songChartName   = songChartnames[id];
        GameManager.gameManager.composerName    = composerNames[id];
        GameManager.gameManager.charterName     = charterNames[id];
    }

    public int getLevel_easy(int id)
    {
        return levelEasy[id];
    }

    public int getLevel_hard(int id)
    {
        return levelHard[id];
    }

    private int GetMaxID()
    {
        if(songDisplayNames.Length == songSourceNames.Length && songDisplayNames.Length == songChartnames.Length &&
           songDisplayNames.Length == composerNames.Length   && songDisplayNames.Length == charterNames.Length) {
            return songDisplayNames.Length - 1;
        }
        else {
            Debug.LogError("[error:SongTable] Song length mismatch !!");
            return -1;
        }
    }
}
