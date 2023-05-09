using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideNote : Note
{
    private InputManager inputManager;
    private EffectManager effectManager;

    private void Start()
    {
        inputManager  = GameObject.Find("InputManager").GetComponent<InputManager>();
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }

    private void Update()
    {
        if(RhythmGameManager.instance.isChartGenerated) {
            if(!RhythmGameManager.instance.isPaused) {
                // Updates
                UpdatePosition();
                UpdateTime();
                TryDestroy();

                // Judgement
                if(!isAuto) {
                    if(time < 0.15f) {
                        Judge();
                    }
                }
                else {
                    AutoJudge();
                }
            }
        }
    }

    public void setSize()
    {
        transform.root.transform.localScale = new Vector3(
            transform.root.transform.localScale.x*size,
            transform.root.transform.localScale.y,
            transform.root.transform.localScale.z
        );
    }

    private void TryDestroy()
    {
        if(time < -0.15f) {
            effectManager.ShowJudgeEffect(id:0, transform.position.x);
            Destroy(transform.root.gameObject);
        }
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

    private void Judge()
    {
        bool CheckState()
        {
            foreach(int lane in lanes) {
                if(inputManager.GetDragState(lane)) {
                    return true;
                }
            }
            return false;
        }

        // Just
        if(-0.1f < time && time < 0f) {
            if(CheckState()) {
                effectManager.ShowJudgeEffect(id:1, x:transform.position.x);
                effectManager.PlayJudgeEffect();
                Destroy(transform.root.gameObject);
            }
        }
    }
}
