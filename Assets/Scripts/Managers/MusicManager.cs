using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string songSourceName;

    private void Start()
    {
        songSourceName = GameManager.gameManager.songSourceName;
        audioSource  = GetComponent<AudioSource>();
        audioClip    = Resources.Load<AudioClip>("Music/" + songSourceName);
        audioSource.clip = audioClip;

        Play();
    }

    public void Toggle()
    {
        if(GameManager.gameManager.isPaused) {
            Pause();
        }
        else {
            Resume();
        }
    }

    private void Play()
    {
        audioSource.Play();
    }

    private void Resume()
    {
        audioSource.UnPause();
    }

    private void Pause()
    {
        audioSource.Pause();
    }
}
