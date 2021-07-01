using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLoad : MonoBehaviour
{
    public static DontDestroyLoad instance;


    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
}
