using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSystem : MonoBehaviour
{
    [SerializeField] int requiredDesignProgress;
    [SerializeField] int designProgress = 0; // For debug puroses

    GameTime gameTime;


    // Start is called before the first frame update
    void Start()
    {
        gameTime = GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Progress(int design)
    {
        Debug.Log("Executed");
        requiredDesignProgress = design;
        designProgress++;
        if (designProgress == requiredDesignProgress)
        {
            gameTime.SetProjectISDone();
        }
    }
}
