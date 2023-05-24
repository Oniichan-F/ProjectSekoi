
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
    [SerializeField] GameObject tapNoteObj;
    [SerializeField] GameObject flickNoteObj;

    [SerializeField] GameObject longNoteObj;
    [SerializeField] GameObject headNoteObj;
    [SerializeField] GameObject relayNoteObj;

    private float[] X = {-3f, -2.5f, -2f, -1.5f, -1f, -0.5f, 0f, 0.5f, 1f, 1.5f, 2f, 2.5f};

    private string songChartName;
    private float baseNoteSpeed;
    private int userOffset;

    private void OnEnable()
    {
        if(GameManager.gameManager.difficulty == 0) {
            songChartName = GameManager.gameManager.songChartName + "_easy";
        }
        else if(GameManager.gameManager.difficulty == 1) {
            songChartName = GameManager.gameManager.songChartName + "_hard";
        }
        baseNoteSpeed = GameManager.gameManager.speed * 10f;

        Load(songChartName);
    }

    private void Load(string songChartName)
    {
        string jsonFile = Resources.Load<TextAsset>("Chart/" + songChartName).ToString();
        ChartData chartData = JsonUtility.FromJson<ChartData>(jsonFile);

        for(int i = 0; i < chartData.notes.Length; i++) {
            NoteData noteData = chartData.notes[i];

            // TapNote
            if(noteData.type == 1) {
                int[] lanes = noteData.block;
                float time  = CalcTime(chartData, noteData);
                float z     = time * baseNoteSpeed;

                GameObject instance = Instantiate(
                    tapNoteObj,
                    new Vector3(X[lanes[0]], 0.02f, z),
                    Quaternion.identity
                );

                TapNote note = instance.GetComponentInChildren<TapNote>();
                note.Init(id:i, group:0, lanes:lanes, speed:baseNoteSpeed, time:time);
                note.setSize();
            }

            // FlickNote
            else if(noteData.type == 2) {
                int[] lanes = noteData.block;
                float time  = CalcTime(chartData, noteData);
                float z     = time * baseNoteSpeed;

                GameObject instance = Instantiate(
                    flickNoteObj,
                    new Vector3(X[lanes[0]], 0.02f, z),
                    Quaternion.identity
                );

                FlickNote note = instance.GetComponentInChildren<FlickNote>();
                note.Init(id:i, group:0, lanes:lanes, speed:baseNoteSpeed, time:time);
                note.setSize();
            }

            // LongNote
            else if(noteData.type == 10) {
                NoteData[] children = noteData.notes;

                // LongNote
                LongNote longNote = Instantiate(
                    longNoteObj,
                    new Vector3(0f, 0f, 0f),
                    Quaternion.identity
                ).GetComponent<LongNote>();
                float startWidth = 1f;
                float endWidth   = 1f;
                //longNote.setOptions(1,1,5);

                for(int j = 0; j < children.Length; j++) {
                    NoteData child = children[j];

                    // HeadNote
                    if(child.type == 11) {
                        int[] lanes = child.block;
                        float time  = CalcTime(chartData, child);
                        float z     = time * baseNoteSpeed;

                        HeadNote headNote = Instantiate(
                            headNoteObj,
                            new Vector3(X[lanes[0]], 0.02f, z),
                            Quaternion.identity
                        ).GetComponentInChildren<HeadNote>();

                        headNote.Init(id:i, group:0, lanes:lanes, speed:baseNoteSpeed, time:time);
                        headNote.setSize();

                        headNote.transform.root.parent = longNote.transform;
                        longNote.headNote = headNote;
                        startWidth = headNote.size / 2f;
                    }

                    // RelayNote
                    else if(child.type == 12) {
                        int[] lanes = child.block;
                        float time  = CalcTime(chartData, child);
                        float z     = time * baseNoteSpeed;

                        RelayNote relayNote = Instantiate(
                            relayNoteObj,
                            new Vector3(X[lanes[0]], 0.02f, z),
                            Quaternion.identity
                        ).GetComponentInChildren<RelayNote>();

                        relayNote.Init(id:i, group:0, lanes:lanes, speed:baseNoteSpeed, time:time);
                        relayNote.setSize();

                        if(j == children.Length-1) {
                            relayNote.isTail = true;
                            endWidth = relayNote.size / 2f;
                        }

                        relayNote.transform.root.parent = longNote.transform;
                        longNote.relayNotes.Add(relayNote);
                    }
                }
                longNote.setOptions(startWidth, endWidth, 5);
            }
            else if(noteData.type == -1) {
                break;
            }
        }

        GameManager.gameManager.isChartGenerated = true;
    }

    private float CalcTime(ChartData cd, NoteData nd)
    {
        float interval = 60f / (cd.BPM * nd.LPB);
        float beatsec  = interval * (float)nd.LPB;
        float time     = (beatsec * nd.num / (float)nd.LPB) + cd.offset * 0.01f;
        return time;
    }

}
