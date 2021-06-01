using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plantation : MonoBehaviour
{
    public enum PlantType { Wheat, Beans, Corn };
    public  Sprite[] plantProgress = new Sprite[4];
    public ProgressBar progressBar;
    public  List<DnaUpgrade> upgrades = new List<DnaUpgrade>();
    private bool[] enhancements = new bool[4];
    private PlantType type;
    private int heatResistance = 1;
    private int coldResistance = 1;
    private int floodResistance = 1;
    private int pestResistance = 1;
    private int droughtResistance = 1;
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
                heatResistance++;
                floodResistance++;
                droughtResistance--;
                break;
            case PlantType.Wheat:
                coldResistance++;
                pestResistance++;
                floodResistance--;
                break;
            case PlantType.Corn:
                break;
        }
    }

    public Plantation(Plantation plantation)
    {
        this.type = plantation.type;
        int[] resistances = plantation.getResistances();
        this.coldResistance = resistances[0];
        this.heatResistance = resistances[1];
        this.floodResistance = resistances[2];
        this.pestResistance = resistances[3];
        this.droughtResistance = resistances[4];
        this.timeToCollect = 0;
        this.upgrades = plantation.upgrades;

    }

    public int getHeatResistance()
    {
        return heatResistance;
    }
    public void increaseColdResistance()
    {
        coldResistance++;
    }
    public void decreaseColdResistance()
    {
        coldResistance--;
    }
    public void increaseHeatResistance()
    {
        heatResistance++;
    }
    public void decreaseHeatResistance()
    {
        heatResistance--;
    }
    public void increaseFloodResistance()
    {
        floodResistance++;
    }
    public void decreaseFloodResistance()
    {
        floodResistance--;
    }

    public void increasePestResistance()
    {
        pestResistance++;

    }
    public void decreasePestResistance()
    {
        pestResistance--;
    }

    public void increaseDroughtResistance()
    {
        droughtResistance++;
    }
    public void decreaseDroughtResistance()
    {
        droughtResistance--;
    }

    public void addUpgrade(DnaUpgrade upgrade)
    {
        upgrades.Add(upgrade);
    }

    public bool hasUpgrade(DnaUpgrade upgrade)
    {
        return upgrades.Contains(upgrade);
    }
    public PlantType getType()
    {
        return type;
    }

    public int[] getResistances()
    {
        int[] resistances = new int[5];
        resistances[0] = coldResistance;
        resistances[1] = heatResistance;
        resistances[2] = floodResistance;
        resistances[3] = pestResistance;
        resistances[4] = droughtResistance;
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
                heatResistance++;
                floodResistance++;
                break;
            case 1:
                coldResistance++;
                if (droughtResistance > 0) droughtResistance--;
                break;
            case 2:
                pestResistance++;
                coldResistance++;
                break;
            case 3:
                heatResistance++;
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
            GameMaster.GM.plantationManager.plantationAlive(id);
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
        if (live)
        {
            timeToCollect = 0;
            GameMaster.GM.foodPoints += 200;
            GameMaster.GM.dnaPoints += 500;
            readyToHarvest = false;
            progressBar.SetProgress(0);
            updateSprite();
        }
    }

    public void updateSprite()
    {
        image = GameObject.FindGameObjectWithTag("Crops").transform.GetChild(id).GetComponent<Image>();
        Sprite[] sprites;
        switch (type)
        {
            case PlantType.Beans:
                sprites = GameMaster.GM.beansProgress;
                break;
            case PlantType.Corn:
                sprites = GameMaster.GM.cornProgress;
                break;
            case PlantType.Wheat:
                sprites = GameMaster.GM.wheatProgress;
                break;
            default:
                sprites = GameMaster.GM.beansProgress;
                break;
        }

        if (timeToCollect < 3)
        {
            image.sprite = sprites[0];
        }
        else if (timeToCollect < 6)
        {
            image.sprite = sprites[1];
        }
        else if (timeToCollect <= 9)
        {
            image.sprite = sprites[2];
        }
        else image.sprite = sprites[3];

            progressBar.SetProgress(timeToCollect * 10);
    }

    public void resetPlantation()
    {
        if (live)
        {
            timeToCollect = 0;
            progressBar.SetProgress(0);
            GameMaster.GM.plantationManager.plantationReset(id);
            updateSprite();
        }
    }

    public void delayPlantation()
    {
        if (live)
        {
            timeToCollect -= 2;
            if (timeToCollect < 0)
                timeToCollect = 0;
            progressBar.SetProgress(timeToCollect);
            GameMaster.GM.plantationManager.plantationReset(id);
            updateSprite();
        }
    }
}

