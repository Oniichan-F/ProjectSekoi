using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayNote : Note
{
    private InputManager inputManager;
    private EffectManager effectManager;
    private ScoreManager scoreManager;

    private LongNote longNote;
    private LongNoteRenderer longNoteRenderer;

    public bool isTail;
    private bool isCatched;

    private void Start()
    {
        inputManager  = GameObject.Find("InputManager").GetComponent<InputManager>();
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        longNote = GetComponentInParent<LongNote>();
        longNoteRenderer = longNote.GetComponentInChildren<LongNoteRenderer>();
    }

    private void Update()
    {
        if(GameManager.gameManager.isChartGenerated) {
            if(!GameManager.gameManager.isPaused) {
                // Updates
                UpdatePosition();
                UpdateTime();

                // Judgement
                if(!isAuto) {
                    if(longNote.state == 1) {
                        if(time < 0.0f) {
                            Judge();
                        }
                        if(!isCatched && time < -0.1f) {
                            isTouchable = false;
                            longNote.state = 2;
                            longNoteRenderer.ChangeColor(2);
                            scoreManager.combo = 0;
                            scoreManager.missCount += 1;
                            scoreManager.UpdateCanvas();
                        }
                    }
                }
                else {
                    AutoJudge();
                }

                if(isTail && time < -0.1f) {
                    longNote.Destroy();
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

    private void AutoJudge()
    {
        if(isTouchable) {
            if(time < 0f) {
                if(GameManager.gameManager.isDebugMode) {
                    Debug.Log("auto judge !!");
                }
                effectManager.ShowJudgeEffect(id:1, x:transform.position.x);
                //effectManager.PlayJudgeEffect();

                scoreManager.combo += 1;
                scoreManager.justCount += 1;
                scoreManager.score += 1f / scoreManager.maxCombo;
                scoreManager.UpdateCanvas();

                isTouchable = false;
            }
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

        float timeAbs = Mathf.Abs(time);

        // Just
        if(isTouchable) {
            if(CheckState()) {
                effectManager.ShowJudgeEffect(id:1, x:transform.position.x);
                //effectManager.PlayJudgeEffect();

                scoreManager.combo += 1;
                scoreManager.justCount += 1;
                scoreManager.UpdateCanvas();

                isTouchable = false;
                isCatched = true;
            }
        }
    }
}
