using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [Header("Clock")]
    // gameTime[0] is game minutes and gameTime[1] is game hours
    [SerializeField] int[] gameTime = {0, 0}; //for Debug

    [Header("Day and Night Cycle")]
    [SerializeField] bool isItDay = false; // for Debug

    [Header("External Var")]
    [SerializeField] bool isProjectDone = false;

    //Cached Components
    ProgressSystem progressSystem;

    // Start is called before the first frame update
    void Start()
    {
        gameTime[0] = 0;
        gameTime[1] = 0;

        progressSystem = GetComponent<ProgressSystem>();

        StartCoroutine(TimeConcept());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeConcept()
    {
        while (true)
        {
            gameTime[0]++;
            ExecuteEverySeconds();

            if (gameTime[0] == 60)
            {
                gameTime[0] = 0;
                gameTime[1]++;
                ExecuteEveryMinute();

                if (gameTime[1] == 24)
                {
                    gameTime[1] = 0;
                }
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }


    private void ExecuteEverySeconds()
    {
        ProcessProgress();
    }

    private void ExecuteEveryMinute()
    {
        ProcessDayNightCycle();
    }
    private void ProcessProgress()
    {
        if (!isProjectDone)
        {
            progressSystem.Progress(10);
        }
    }

    private void ProcessDayNightCycle()
    {
        if (gameTime[1] < 7 | gameTime[1] > 17)
        {
            isItDay = false;
        }
        else
        {
            isItDay = true;
        }
    }

    public int[] GetTime() { return gameTime; }

    public void SetProjectISDone() 
    { 
        isProjectDone = true; 
    }
}
