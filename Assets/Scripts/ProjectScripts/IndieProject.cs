using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IndieProject class inherited BaseProject
/// because the parent class also inherited MonoBehaviour
/// so the child class will also inherite MonoBehaviour
/// and all the Unity specific classes would work
/// </summary>
public class IndieProject : BaseProject
{
    //Indie Progression
    [Header("Indie")]
    [SerializeField] int moddeling;

    void soemthing()
    {
        
    }
}
