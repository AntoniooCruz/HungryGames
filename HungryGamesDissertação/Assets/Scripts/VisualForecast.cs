using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualForecast : MonoBehaviour
{
    private void Update()
    {
        VisualUpdate();
    }
    private void VisualUpdate()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        switch (GameMaster.GM.forecastHandler.getForecast())
        {
            case ForecastHandler.Forecast.Snow:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case ForecastHandler.Forecast.HeatWave:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case ForecastHandler.Forecast.Flood:
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            case ForecastHandler.Forecast.Pest:
                transform.GetChild(4).gameObject.SetActive(true);
                break;
            case ForecastHandler.Forecast.Drought:
                transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
    }
}
