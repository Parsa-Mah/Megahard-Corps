using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSystem : MonoBehaviour
{
    //Goals in numbers to reach
    [Header("Requirements")]
    //Pre-Production
    [SerializeField] int writingGoal = 0; // For debug puroses
    [SerializeField] int roadmapGoal = 0; // For debug puroses

    //Production
    [SerializeField] int designGoal = 0; // For debug puroses
    [SerializeField] int programmingGoal = 0; // For debug puroses
    [SerializeField] int effectsGoal = 0; // For debug puroses
    [SerializeField] int engineGoal = 0; // For debug puroses

    //Testing
    [SerializeField] int testingGoal = 0;

    //Post-Launch
    [SerializeField] bool isSupported = true;
    /*************************************************************/

    //Progress in numbers per realtime seconds until we reach our goal number
    [Header("x Per Seconds")]
    //Pre-Production
    [SerializeField] int writingProgress = 0; // For debug puroses
    [SerializeField] int roadmapProgress = 0; // For debug puroses

    //Production
    [SerializeField] int designProgress = 0; // For debug puroses
    [SerializeField] int programmingProgress = 0; // For debug puroses
    [SerializeField] int effectsProgress = 0; // For debug puroses
    [SerializeField] int engineProgress = 0; // For debug puroses

    //Testing
    [SerializeField] int testingProgress = 0;
    /*************************************************************/

    //Cached objects
    GameTime gameTime;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = GetComponent<GameTime>();
    }

    public void SetRequirements(
        int writingGoal,
        int roadmapGoal,
        int designGoal,
        int programmingGoal,
        int effectsGoal,
        int engineGoal,
        int testingGoal)
    {
        //Pre-Production
        this.writingGoal = writingGoal;
        this.roadmapGoal = roadmapGoal;

        //Production
        this.designGoal =  designGoal;
        this.programmingGoal = programmingGoal;
        this.effectsGoal = effectsGoal;
        this.engineGoal =  engineGoal;

        //Testing
        this.testingGoal = testingGoal;
    }

    public void SetProgressPerSeconds(
        int writingProgress,
        int roadmapProgress,
        int designProgress,
        int programmingProgress,
        int effectsProgress,
        int engineProgress,
        int testingProgress)
    {
        //Pre-Production
        this.writingProgress = writingProgress;
        this.roadmapProgress = roadmapProgress;

        //Production
        this.designProgress =  designProgress;
        this.programmingProgress = programmingProgress;
        this.effectsProgress = effectsProgress;
        this.engineProgress =  engineProgress;

        //Testing
        this.testingProgress = testingProgress;
    }

    public IEnumerator BeginePhase1()
    {
        while (true)
        {
            writingProgress += writingProgress;
            roadmapProgress += roadmapProgress;

            if (writingProgress == writingGoal & roadmapProgress == roadmapGoal)
            {
                StartCoroutine(BeginePhase2());
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator BeginePhase2()
    {
        while (true)
        {
            designProgress += designProgress;
            programmingProgress += programmingProgress;
            effectsProgress += effectsProgress;
            engineProgress += engineProgress;

            if (designProgress == designGoal &
                programmingProgress == programmingGoal &
                effectsProgress == effectsGoal &
                engineProgress == engineGoal)
            {
                StartCoroutine(BeginePhase3());
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator BeginePhase3()
    {
        while (true)
        {
            testingProgress += testingProgress;

            if (testingProgress == testingGoal)
            {
                StartCoroutine(ReleaseProduct());
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ReleaseProduct()
    {
        while (isSupported)
        {
            //generate costs
            yield return new WaitForSeconds(60f);
        }
    }
}
