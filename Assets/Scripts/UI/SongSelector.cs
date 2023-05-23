using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelector : MonoBehaviour
{
    [SerializeField] SongTable songTable;
    [SerializeField] Jacket jacket;
    [SerializeField] SongInfo songInfo;

    public void onNextButtonClick()
    {
        if(GameManager.gameManager.songID >= songTable.maxID) {
            GameManager.gameManager.songID = 0;
        }
        else {
            GameManager.gameManager.songID += 1;
        }

        songTable.SetSongInfoFromID(GameManager.gameManager.songID);
        jacket.ChangeJacket();
        songInfo.ChangeSongInfo();
    }

    public void onPrevButtonClick()
    {
        if(GameManager.gameManager.songID <= 0) {
            GameManager.gameManager.songID = songTable.maxID;
        }
        else {
            GameManager.gameManager.songID -= 1;
        }

        songTable.SetSongInfoFromID(GameManager.gameManager.songID);
        jacket.ChangeJacket();
        songInfo.ChangeSongInfo();
    }
}
