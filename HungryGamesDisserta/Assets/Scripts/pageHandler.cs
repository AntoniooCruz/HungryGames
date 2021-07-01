using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageHandler : MonoBehaviour
{
    public void nextPage()
    {
     
        if (GameMaster.GM.plantationManager.plantPage < (PlantationManager.plantations.Count - 1) / 3)
            GameMaster.GM.plantationManager.plantPage++;

        GameMaster.GM.plantationManager.activatePlantPage(GameMaster.GM.plantationManager.plantPage);
    }

    public void previousPage()
    {
   
        if (GameMaster.GM.plantationManager.plantPage > 0)
            GameMaster.GM.plantationManager.plantPage--;

        GameMaster.GM.plantationManager.activatePlantPage(GameMaster.GM.plantationManager.plantPage);
    }
}
