using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public PlantationManager plantationManager;
    public DisplayResistance displayResistance;

    void Awake()
    {
   
        if (GM == null)
            GM = this;
        else if (GM != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
}