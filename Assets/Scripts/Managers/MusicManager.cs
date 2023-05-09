using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string songFileName;

    private void Start()
    {
        songFileName = RhythmGameManager.instance.songFileName;
        audioSource  = GetComponent<AudioSource>();
        audioClip    = Resources.Load<AudioClip>("Music/" + songFileName);
        audioSource.clip = audioClip;

        Play();
    }

    public void Toggle()
    {
        if(RhythmGameManager.instance.isPaused) {
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
