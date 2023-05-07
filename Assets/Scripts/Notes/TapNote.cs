using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNote : Note
{
    private EffectManager effectManager;

    private void Start()
    {
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }

    private void Update()
    {
        if(RhythmGameManager.instance.tmp) {
            // Updates
            UpdatePosition();
            UpdateTime();

            // Judgement
            if(!isAuto) {

            }
            else {
                AutoJudge();
            }
        }
    }

    public void setSize()
    {
        transform.localScale = new Vector3(transform.localScale.x*size, transform.localScale.y, transform.localScale.z);
    }

    private void AutoJudge()
    {
        if(time < 0f) {
            if(RhythmGameManager.instance.isDebugMode) {
                Debug.Log("auto judge !!");
            }
            effectManager.ShowJudgeEffect(id:1, x:transform.position.x);
            effectManager.PlayJudgeEffect();

            Destroy(transform.root.gameObject);
        }
    }
}
