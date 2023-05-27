using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCanvas : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void UpdateCombo()
    {
        transform.Find("Combo").GetComponent<TextMeshProUGUI>().text = scoreManager.combo.ToString();
        transform.Find("Combo").GetComponent<Animation>().Play();

        if(scoreManager.justCount == scoreManager.maxCombo) {
            transform.Find("Score").GetComponent<TextMeshProUGUI>().text = "1000000";
        }
        else {
            transform.Find("Score").GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(1000000f *(scoreManager.score)).ToString().PadLeft(7, '0');
        }
    }
}
