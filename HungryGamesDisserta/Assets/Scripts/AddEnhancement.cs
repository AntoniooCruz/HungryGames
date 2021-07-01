using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnhancement : MonoBehaviour
{
    public int id;
    
    public void buyEnhancement()
    {
        PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].addEnhancement(id);
    }
  
}
