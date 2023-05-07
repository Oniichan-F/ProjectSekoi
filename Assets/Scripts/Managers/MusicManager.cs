using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string songFileName;
    private bool isPlaying;

    private void Start()
    {
        songFileName = RhythmGameManager.instance.songFileName;
        audioSource  = GetComponent<AudioSource>();
        audioClip    = Resources.Load<AudioClip>("Music/" + songFileName);
        isPlaying = false; 
    }

    private void Update() {
        if(!isPlaying) {
            if(RhythmGameManager.instance.tmp) {
                audioSource.PlayOneShot(audioClip);
                isPlaying = true;
            }
        }
    }

    public void Play()
    {
        audioSource.PlayOneShot(audioClip);
        isPlaying = true;
    }
}
