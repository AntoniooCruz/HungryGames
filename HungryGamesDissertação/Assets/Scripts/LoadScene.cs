using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
   public void SceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadDnaModifiers(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Plantation plant = gameObject.GetComponentInParent<Plantation>();
        //  GameMaster.GM.plantationManager.plantations[0].increaseHeatResistance();
        GameMaster.GM.displayResistance.LoadResistances(plant.getId());
 
    }

    public void LoadHome(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        GameMaster.GM.plantationManager.instantiatePlantations();
        Debug.Log(PlantationManager.plantations[0].getEnhancements()[0]);
    }

    public void LoadDnaEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Plantation plant = gameObject.GetComponentInParent<Plantation>();
        GameMaster.GM.plantationManager.currentPlant = plant.getId();

    }
}
