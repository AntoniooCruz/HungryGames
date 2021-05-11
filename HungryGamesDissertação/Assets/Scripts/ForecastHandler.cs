using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForecastHandler : MonoBehaviour
{
    public enum Forecast { Snow, HeatWave, Pest, Drought, Flood };
    private static Forecast forecast = Forecast.Snow;
    public void UpdateForecast()
    {
        PlantationUpdate();
        changeForecast();
       
    }

    public Forecast getForecast()
    {
        return forecast;
    }

    private void changeForecast()
    {
        forecast = (Forecast)Random.Range(0, 4);
    }


    private void PlantationUpdate()
    {
        switch (forecast)
        {
            case Forecast.Snow:
                handleSnow();
                break;
            case Forecast.HeatWave:
                handleHeatWave();
                break;
            case Forecast.Flood:
                handleFlood();
                break;
            case Forecast.Pest:
                handlePest();
                break;
            case Forecast.Drought:
                handleDrought();
                break;
        }
        
    }

    private void handleSnow()
    {
        foreach(Plantation plantation in PlantationManager.plantations)
        {
            plantation.killPlantation();
        }
    }

    private void handleHeatWave()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            plantation.killPlantation();

        }
    }

    private void handleFlood()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            //plantation.killPlantation();

        }
    }

    private void handlePest()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            //plantation.killPlantation();

        }
    }

    private void handleDrought()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            //plantation.killPlantation();

        }
    }

}
