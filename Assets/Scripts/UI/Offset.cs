using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Offset : MonoBehaviour
{
    private void Start()
    {
        ChangeOffsetText();
    }

    public void UP()
    {
        if(GameManager.gameManager.offset < 100) {
            GameManager.gameManager.offset += 1;
            ChangeOffsetText();
        }
    }

    public void Down()
    {
        if(GameManager.gameManager.offset > -100) {
            GameManager.gameManager.offset -= 1;
            ChangeOffsetText();
        }
    }

    private void ChangeOffsetText()
    {
        transform.Find("Value_Offset").GetComponent<TextMeshProUGUI>().text = GameManager.gameManager.offset.ToString();
    }
}
