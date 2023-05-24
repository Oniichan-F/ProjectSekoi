using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoPlay : MonoBehaviour
{
    public void onClick()
    {
        GameManager.gameManager.isAutoPlay = true;
        SceneManager.LoadScene("GameScene");
    }
}
