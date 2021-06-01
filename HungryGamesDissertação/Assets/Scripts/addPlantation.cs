using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPlantation : MonoBehaviour
{
    public void addWheat()
    {
        if (GameMaster.GM.dnaPoints >= 900)
        {
            GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Wheat);
            GameMaster.GM.dnaPoints -= 900;
        }
    }
        

    public void addBeans()
    {
        if (GameMaster.GM.dnaPoints >= 900)
        {
            GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Beans);
            GameMaster.GM.dnaPoints -= 900;
        }
    }

    public void addCorn()
    {
        if (GameMaster.GM.dnaPoints >= 900)
        {
            GameMaster.GM.plantationManager.addPlantation(Plantation.PlantType.Corn);
            GameMaster.GM.dnaPoints -= 900;
        }
    }

    public void addSpecificCrop()
    {
        if (GameMaster.GM.dnaPoints >= 1650)
        {
            Plantation newPlant = new Plantation(gameObject.GetComponentInParent<VisualPlantation>().plantation);
            GameMaster.GM.plantationManager.addPlantation(newPlant);
            GameMaster.GM.plantationManager.choosingPlantation = false;
            GameMaster.GM.dnaPoints -= 1650;
        }
    }

}
