using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfo : MonoBehaviour
{
    public void ChangeSongInfo()
    {
        string songDisplayName = GameManager.gameManager.songDisplayName;
        string composerName    = GameManager.gameManager.composerName;
        string charterName     = GameManager.gameManager.charterName;

        string stringBuilder = songDisplayName + "\n" +
                               "Composer: " + composerName + "\n" +
                               "Charter : " + charterName;
        
        GetComponent<TextMeshProUGUI>().text = stringBuilder;
    }
}
