using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plantation : MonoBehaviour
{
    public enum PlantType { Wheat, Beans, Grain };
    public  Sprite[] plantProgress = new Sprite[4];
    public ProgressBar progressBar;
    private bool[] enhancements = new bool[4];
    private PlantType type;
    private int heatResitance = 1;
    private int coldResistance = 1;
    private int floodResistance = 1;
    private int pestResistance = 1;
    private int droughtsResistance = 1;
    private int timeToCollect = 0;
    private int id;
    private bool live = true;
    bool readyToHarvest = false;

    Image image;

    private void Start()
    {
        image = GameObject.FindGameObjectWithTag("Crops").transform.GetChild(id).GetComponent<Image>();
        plantProgress = GameMaster.GM.plantationManager.BeansProgress;
        //image.sprite = plantProgress[0];

    }
    public Plantation(PlantType type)
    {
        this.type = type;
        switch (type)
        {
            case PlantType.Beans:
                heatResitance++;
                floodResistance++;
                droughtsResistance--;
                break;
            case PlantType.Wheat:
                coldResistance++;
                pestResistance++;
                floodResistance--;
                break;
            case PlantType.Grain:
                break;
        }
    }

    public int getHeatResistance()
    {
        return heatResitance;
    }

    public void increaseHeatResistance()
    {
        heatResitance++;
    }
    public void decreaseHeatResistance()
    {
        heatResitance--;
    }

    public PlantType getType()
    {
        return type;
    }

    public int[] getResistances()
    {
        int[] resistances = new int[4];
        resistances[0] = coldResistance;
        resistances[1] = heatResitance;
        resistances[2] = pestResistance;
        resistances[3] = droughtsResistance;
        //resistances[4] = floodResistance;
        return resistances;
    }

    public int getId()
    {
        return id;
    }

    public bool[] getEnhancements()
    {
        return enhancements;
    }

    public bool isAlive()
    {
        return this.live;
    }

    public void killPlantation()
    {
        live = false;
        GameMaster.GM.plantationManager.plantationDied(id);
    }

    public void addEnhancement(int id)
    {
        enhancements[id] = true;
        switch (id)
        {
            case 0:
                heatResitance++;
                floodResistance++;
                break;
            case 1:
                coldResistance++;
                if (droughtsResistance > 0) droughtsResistance--;
                break;
            case 2:
                pestResistance++;
                coldResistance++;
                break;
            case 3:
                heatResitance++;
                if (coldResistance > 0) coldResistance--;
                break;

        }
    }
    public void setId(int id)
    {
        this.id = id;
    }

    public void nextTurn()
    {
        if (live)
        {
            if (timeToCollect < 10)
                timeToCollect++;
            progressBar.SetProgress(timeToCollect * 10);
            if (timeToCollect >= 10)
            {
                readyToHarvest = true;
                GameMaster.GM.plantationManager.readyPlantationHarvest(id);
            }
            updateSprite();
        }
        
    }

    public void harvestPlantation()
    {
        timeToCollect = 0;
        GameMaster.GM.foodPoints += 200;
        GameMaster.GM.dnaPoints += 500;
        readyToHarvest = false;
        progressBar.SetProgress(0);
        updateSprite();
    }

    public void updateSprite()
    {
        image = GameObject.FindGameObjectWithTag("Crops").transform.GetChild(id).GetComponent<Image>();
        if (timeToCollect < 3)
        {
            image.sprite = GameMaster.GM.beansProgress[0];
        }
        else if (timeToCollect < 6)
        {
            image.sprite = GameMaster.GM.beansProgress[1];
        }
        else if (timeToCollect <= 9)
        {
            image.sprite = GameMaster.GM.beansProgress[2];
        }
        else image.sprite = GameMaster.GM.beansProgress[3];

            progressBar.SetProgress(timeToCollect * 10);
    }
}

