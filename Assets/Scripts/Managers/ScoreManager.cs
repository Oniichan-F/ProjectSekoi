using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int combo;
    public int maxCombo;
    public int justCount;
    public int greatCount;
    public int goodCount;
    public int missCount;

    private void Start()
    {
        score = 0;
        combo = 0;
        justCount  = 0;
        greatCount = 0;
        goodCount  = 0;
        missCount  = 0;   
    }
}
