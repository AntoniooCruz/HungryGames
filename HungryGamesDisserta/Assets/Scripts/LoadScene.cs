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
        Plantation plant = gameObject.GetComponentInParent<VisualPlantation>().plantation;
        //  GameMaster.GM.plantationManager.plantations[0].increaseHeatResistance();
        GameMaster.GM.displayResistance.LoadResistances(plant.getId());
 
    }

    public void LoadHome(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        GameMaster.GM.plantationManager.instantiatePlantations();
      //  Debug.Log(PlantationManager.plantations[0].getEnhancements()[0]);
    }

    public void LoadChoosePlantation(int sceneIndex)
    {
        if (GameMaster.GM.dnaPoints >= 1650)
        {
            SceneManager.LoadScene(sceneIndex);
            GameMaster.GM.plantationManager.choosingPlantation = true;
            GameMaster.GM.plantationManager.instantiatePlantations();
        }

    }

    public void LoadDnaEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Plantation plant = gameObject.GetComponentInParent<VisualPlantation>().plantation;
        GameMaster.GM.plantationManager.currentPlant = plant.getId();

    }

    public void LoadColdEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        GameMaster.GM.displayUpgrades.forecast = ForecastHandler.Forecast.Cold;
    }

    public void LoadHeatEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        GameMaster.GM.displayUpgrades.forecast = ForecastHandler.Forecast.Heat;
    }

    public void LoadPestEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        GameMaster.GM.displayUpgrades.forecast = ForecastHandler.Forecast.Pest;
    }

    public void LoadFloodEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        GameMaster.GM.displayUpgrades.forecast = ForecastHandler.Forecast.Flood;
    }

    public void LoadDroughtEnhancer(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        GameMaster.GM.displayUpgrades.forecast = ForecastHandler.Forecast.Drought;
    }

    public void LoadNewGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        if(GameMaster.GM != null)
            GameMaster.GM.newGame();
    }
}
