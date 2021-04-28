using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayResistance : MonoBehaviour
{
    public int[] resistances = new int[4];
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(resistances[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadResistances(int plantId)
    {
        this.resistances = PlantationManager.plantations[plantId].getResistances();
    }
}
