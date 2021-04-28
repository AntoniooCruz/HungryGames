using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPlantation : MonoBehaviour
{
    public void addWheat()
    {
        GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Wheat);
    }

    public void addBeans()
    {
        GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Beans);
    }

    public void addGrain()
    {
        GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Grain);
    }

}
