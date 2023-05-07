using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Visual Effects
    [SerializeField] private GameObject[] judgeEffects;

    // Sound Effects
    private AudioSource audioSource;
    [SerializeField] private AudioClip judgeSE;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void ShowJudgeEffect(int id, float x)
    {
        GameObject obj = Instantiate(
            judgeEffects[id],
            new Vector3(x, 0.1f, 0f),
            Quaternion.Euler(45f, 0f, 0f)
        );
        Destroy(obj, 0.5f);
    }

    public void PlayJudgeEffect()
    {
        audioSource.PlayOneShot(judgeSE);
    }
}
