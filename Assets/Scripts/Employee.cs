using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    // Characteristics
    [Header("Characteristics")]
    [SerializeField] int experience = 0;
    [SerializeField] int experienceCap = 0;
    [SerializeField] int level = 1;
    [SerializeField] bool canLevelUp = true;
    [SerializeField] int age = 18;
    [SerializeField] int programming = 0;
    [SerializeField] int design = 0;
    [SerializeField] bool threeD = false;
    [SerializeField] bool isWriter = false;
    [SerializeField] int writing = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetCharacteristics(
        int experience,
        int level,
        bool canLevelUp,
        int age,
        int programming,
        int design,
        bool threeD,
        bool isWriter,
        int writing)
    {
        this.experience = experience;
        this.level = level;
        this.canLevelUp = canLevelUp;
        this.age = age;
        this.programming = programming;
        this.design = design;
        this.threeD = threeD;
        this.isWriter = isWriter;
        this.writing = writing;
        
    }

    private void SetexperienceCap()
    {
        // for a steady increas in XP cap, to not go up suddenly
        // Xp cap goes up by 5 in each cases in compare to previous case
        // for example 
        // 10 * 50 = 50  ;  11 * 4 + 11 = 55 
        // or
        // 20 * 4 + 20 = 100  ;  (21 * 3) + (21 * 2) = 105
        if (level < 11)
        {
            experienceCap = level * 5 * 60;
        }
        else if (level < 21)
        {
            experienceCap = ((level * 4) + level) * 60;
        }
        else
        {
            experienceCap = ((level * 3) + (level * 2)) * 60;
        }
    }

    private void CalculateCanLevelUp()
    {
        // attrition is the percentage that will be substracted
        // from 100% to randomize the chance of getting leveled up
        byte attrition = 0;

        if (age >= 25 & age < 30)
        {
            attrition += 2;
        }
        else if (age >= 30 & age < 40)
        {
            attrition += 7;
        }
        else if (age >= 40)
        {
            attrition += 12;
        }

        if (level < 5)
        {
            attrition = 0;
        }
        else if (level < 10)
        {
            attrition += 1;
        }
        else if(level < 15)
        {
            attrition += 2;
        }
        else if (level < 20)
        {
            attrition += 4;
        }
        else if (level < 25)
        {
            attrition += 6;
        }
        else if (level <= 30)
        {
            attrition += 9;
        }
        Debug.Log("attrition" + attrition);


        if (UnityEngine.Random.Range(0, 100) < attrition)
        {
            canLevelUp = false;
        }
    }

    public void StartLevelUping()
    {
        StartCoroutine(LevelUp());
    }

    public IEnumerator LevelUp() 
    {
        while (true)
        {
            if (canLevelUp)
            {
                level++;
                CalculateCanLevelUp();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}