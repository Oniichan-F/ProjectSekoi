using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndNote : Note
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        UpdateTime();

        if(time < 0f) {
            Debug.Log("End!!");
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(3);
        setResult();
        SceneManager.LoadScene("ResultScene");
    }

    private void setResult()
    {
        GameManager.gameManager.score      = scoreManager.score;
        GameManager.gameManager.justCount  = scoreManager.justCount;
        GameManager.gameManager.greatCount = scoreManager.greatCount;
        GameManager.gameManager.goodCount  = scoreManager.goodCount;
        GameManager.gameManager.missCount  = scoreManager.missCount;
    }
}
