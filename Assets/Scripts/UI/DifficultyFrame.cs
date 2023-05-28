using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyFrame : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Sprite easyFrame;
    [SerializeField] Sprite hardFrame;
    public float t;

    private void Start()
    {
        t = 1f;
        ChangeDifficultyFrameColor();
    }

    private void Update()
    {
        if(transform.rotation.z < 60f) {
            transform.rotation = Quaternion.Lerp(
                Quaternion.Euler(0f, 0f, 30f),
                Quaternion.Euler(0f, 0f, 60f),
                t
            );
        }

        if(t < 1f) {
            t += rotationSpeed * Time.deltaTime;
        }
    }

    public void RotateDiffucultyFrame()
    {
        t = 0f;
    }

    public void ChangeDifficultyFrameColor()
    {
        // easy
        if(GameManager.gameManager.difficulty == 0) {
            GetComponent<Image>().sprite = easyFrame;
        }
        // hard
        else if(GameManager.gameManager.difficulty == 1) {
            GetComponent<Image>().sprite = hardFrame;
        }
    }
}
