using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    private void Start()
    {
        if(GameManager.gameManager.justCount == GameManager.gameManager.maxCombo) {
            transform.Find("Value_Score").GetComponent<TextMeshProUGUI>().text = "1000000";
        }
        else {
            transform.Find("Value_Score").GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(1000000f *(GameManager.gameManager.score)).ToString().PadLeft(7, '0');
        }

        transform.Find("Value_Detail").GetComponent<TextMeshProUGUI>().text =  GameManager.gameManager.justCount.ToString() + "\n" +
                                                                               GameManager.gameManager.greatCount.ToString() + "\n" +
                                                                               GameManager.gameManager.goodCount.ToString() + "\n" +
                                                                               GameManager.gameManager.missCount.ToString();
    }
}
