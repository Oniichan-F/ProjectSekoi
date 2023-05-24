using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] SongTable songTable;
    [SerializeField] DifficultyFrame difficultyFrame;

    public int easyLevel;
    public int hardLevel;

    private GameObject easyButton;
    private GameObject hardButton;

    private void Start()
    {
        easyButton = transform.Find("Easy").gameObject;
        hardButton = transform.Find("Hard").gameObject;    
    }

    public void ChangeButtonLevels()
    {
        easyLevel = songTable.getLevel_easy(GameManager.gameManager.songID);
        hardLevel = songTable.getLevel_hard(GameManager.gameManager.songID);

        easyButton.GetComponentInChildren<TextMeshProUGUI>().text = easyLevel.ToString();
        hardButton.GetComponentInChildren<TextMeshProUGUI>().text = hardLevel.ToString();
    }

    public void onEasyButtonClick()
    {
        GameManager.gameManager.difficulty = 0;
        difficultyFrame.RotateDiffucultyFrame();
        difficultyFrame.ChangeDifficultyFrameColor();
    }

    public void onHardButtonClick()
    {
        GameManager.gameManager.difficulty = 1;
        difficultyFrame.RotateDiffucultyFrame();
        difficultyFrame.ChangeDifficultyFrameColor();
    }
}
