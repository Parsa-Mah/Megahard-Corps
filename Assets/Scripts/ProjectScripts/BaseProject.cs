using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProject : MonoBehaviour
{
    //Progression
    [Header("Base")]
    [SerializeField] protected int storyProg;
    [SerializeField] protected int scriptingProg;
    [SerializeField] protected int aiProg;
    [SerializeField] protected int uiProg;

    //Testing Phase
    [Header("Finilaization")]
    [SerializeField] protected int testing;
    [SerializeField] protected int debugging;

    //Project is finished
    [SerializeField] protected bool done;

    public void SetProgression(
        int storyProg,
        int scriptingProg,
        int AIProg,
        int UIProg)
    {
        this.storyProg = storyProg;
        this.scriptingProg = scriptingProg;
        this.aiProg = AIProg;
        this.uiProg = UIProg;
    }

    public void WithEveryTick()
    {
        storyProg += storyProg;
        scriptingProg += scriptingProg;
        aiProg += aiProg;
        uiProg += uiProg;

        if (storyProg >= 100 &
            scriptingProg >= 100 &
            aiProg >= 100 &
            uiProg >= 100)
        {
            done = true;
        }
    }
}
