using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForecastHandler : MonoBehaviour
{
    public enum Forecast { Cold, Heat, Pest, Drought, Flood };
    private static Forecast forecast = Forecast.Cold;
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
            case Forecast.Cold:
                handleSnow();
                break;
            case Forecast.Heat:
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
            processResistances(plantation.getResistances()[0], plantation);
        }
    }

    private void handleHeatWave()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            processResistances(plantation.getResistances()[1], plantation);
        }
    }

    private void handleFlood()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            processResistances(plantation.getResistances()[2], plantation);
        }
    }

    private void handlePest()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            processResistances(plantation.getResistances()[3], plantation);
        }
    }

    private void handleDrought()
    {
        foreach (Plantation plantation in PlantationManager.plantations)
        {
            processResistances(plantation.getResistances()[4], plantation);
        }
    }

    private void processResistances(int resistance, Plantation plantation)
    {
        switch (resistance)
        {
            case 0:
                plantation.killPlantation();
                break;
            case 1:
                float randValue = Random.value;
                if (randValue < .8f)
                {
                    plantation.resetPlantation();
                }
                break;
            case 2:
                float randValue2 = Random.value;
                if (randValue2 < .6f)
                {
                    plantation.delayPlantation();
                }
                break;
            default:
                break;

        }
    }

}
