using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        List<ForecastHandler.Forecast> usedForecast = new List<ForecastHandler.Forecast>();
        usedForecast.Add(GameMaster.GM.displayUpgrades.forecast);
        for (int i = 0; i < children; ++i)
        {
            ForecastHandler.Forecast secondType = ForecastHandler.Forecast.Cold;
            foreach (ForecastHandler.Forecast forecast in System.Enum.GetValues(typeof(ForecastHandler.Forecast)))
            {
                if (!usedForecast.Contains(forecast))
                {
                    secondType = forecast;
                    usedForecast.Add(forecast);
                    break;
                }
            }
            DnaUpgrade upgrade = transform.GetChild(i).GetComponent<DnaUpgrade>();
            upgrade.upgradeText(GameMaster.GM.displayUpgrades.forecast, secondType, i == 0);
            if (PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].hasUpgrade(upgrade)){
                upgrade.transform.GetChild(3).GetComponent<Button>().interactable = false;
            }
        }
    }
}


