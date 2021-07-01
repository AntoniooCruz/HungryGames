using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DnaUpgrade : MonoBehaviour
{
    ForecastHandler.Forecast type1;
    ForecastHandler.Forecast type2;
    bool positive;

    public void upgradeText(ForecastHandler.Forecast type1, ForecastHandler.Forecast type2, bool sign)
    {
        this.type1 = type1;
        this.type2 = type2;
        positive = sign;
        transform.GetChild(2).GetComponent<Text>().text = type1.ToString() + System.Environment.NewLine + type2.ToString();
    }

    public void purchaseUpgrade(int price)
    {
        if(GameMaster.GM.dnaPoints >= price)
        {
            GameMaster.GM.dnaPoints -= price;
            PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].addUpgrade(this);
            this.transform.GetChild(3).GetComponent<Button>().interactable = false;
            increaseUpgrade(type1);
            if (positive)
                increaseUpgrade(type2);
            else
                decreaseUpgrade(type2);
        }
        
    }

    private void increaseUpgrade(ForecastHandler.Forecast type)
    {
        switch (type)
        {
            case ForecastHandler.Forecast.Cold:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].increaseColdResistance();
                break;
            case ForecastHandler.Forecast.Heat:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].increaseHeatResistance();
                break;
            case ForecastHandler.Forecast.Flood:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].increaseFloodResistance();
                break;
            case ForecastHandler.Forecast.Pest:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].increasePestResistance();
                break;
            case ForecastHandler.Forecast.Drought:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].increaseDroughtResistance();
                break;
        }
    }

    private void decreaseUpgrade(ForecastHandler.Forecast type)
    {
        switch (type)
        {
            case ForecastHandler.Forecast.Cold:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].decreaseColdResistance();
                break;
            case ForecastHandler.Forecast.Heat:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].decreaseHeatResistance();
                break;
            case ForecastHandler.Forecast.Flood:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].decreaseFloodResistance();
                break;
            case ForecastHandler.Forecast.Pest:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].decreasePestResistance();
                break;
            case ForecastHandler.Forecast.Drought:
                PlantationManager.plantations[GameMaster.GM.plantationManager.currentPlant].decreaseDroughtResistance();
                break;
        }
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        DnaUpgrade d = obj as DnaUpgrade;
        if ((System.Object)d == null)
            return false;
        return (type1 == d.type1) && (type2 == d.type2) && (positive == d.positive);
    }

    public bool Equals(DnaUpgrade d)
    {
        if ((object)d == null)
            return false;
        return (type1 == d.type1) && (type2 == d.type2) && (positive == d.positive);
    }
}
