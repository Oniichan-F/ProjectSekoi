using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    private void Start()
    {
        ChangeSpeedText();
    }

    public void UP()
    {
        if(GameManager.gameManager.speed < 3.91f) {
            GameManager.gameManager.speed += 0.1f;
            ChangeSpeedText();
        }
    }

    public void Down()
    {
        if(GameManager.gameManager.speed > 1.1f) {
            GameManager.gameManager.speed -= 0.1f;
            ChangeSpeedText();
        }
    }

    private void ChangeSpeedText()
    {
        transform.Find("Value_Speed").GetComponent<TextMeshProUGUI>().text = GameManager.gameManager.speed.ToString("f1");
    }
}

