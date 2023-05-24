using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Sprite startImage;
    [SerializeField] Sprite pauseImage;

    private bool isPaused;

    private void Start() 
    {
        isPaused = GameManager.gameManager.isPaused;
        ChangeVisual();
    }

    public void onClick()
    {
        isPaused = !isPaused;
        GameManager.gameManager.isPaused = isPaused;
        ChangeVisual();

    }

    private void ChangeVisual()
    {
        if(isPaused) {
            GetComponent<Image>().sprite = startImage;
        }
        else {
            GetComponent<Image>().sprite = pauseImage;
        }
    }
}
