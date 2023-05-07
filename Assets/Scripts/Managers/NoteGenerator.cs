
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class ChartData
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public NoteData[] notes;
}

[Serializable] public class NoteData
{
    public int type;
    public int num;
    public int[] block;
    public int LPB;
    public NoteData[] notes;
}

public class NoteGenerator : MonoBehaviour
{
    [SerializeField] GameObject tapNote;

    private float[] X = {-3f, -2.5f, -2f, -1.5f, -1f, -0.5f, 0f, 0.5f, 1f, 1.5f, 2f, 2.5f};

    private string chartFileName;
    private float baseNoteSpeed;

    private void OnEnable()
    {
        chartFileName = RhythmGameManager.instance.chartFileName;
        baseNoteSpeed = RhythmGameManager.instance.baseNoteSpeed;
        Load(chartFileName);
    }

    private void Load(string chartFileName)
    {
        string jsonFile = Resources.Load<TextAsset>("Chart/" + chartFileName).ToString();
        ChartData chartData = JsonUtility.FromJson<ChartData>(jsonFile);

        for(int i = 0; i < chartData.notes.Length; i++) {
            NoteData noteData = chartData.notes[i];

            // TapNote
            if(noteData.type == 1) {
                int[] lanes = noteData.block;
                float time  = CalcTime(chartData, noteData);
                float z     = time * baseNoteSpeed;

                GameObject instance = Instantiate(
                    tapNote,
                    new Vector3(X[lanes[0]], 0.02f, z),
                    Quaternion.identity
                );

                TapNote note = instance.GetComponentInChildren<TapNote>();
                note.Init(id:i, group:0, lanes:lanes, time:time);
                note.setSize();
            }
        }

        RhythmGameManager.instance.isChartGenerated = true;
    }

    private float CalcTime(ChartData cd, NoteData nd)
    {
        float interval = 60f / (cd.BPM * nd.LPB);
        float beatsec  = interval * (float)nd.LPB;
        float time     = (beatsec * nd.num / (float)nd.LPB) + cd.offset * 0.01f;
        return time;
    }

}
