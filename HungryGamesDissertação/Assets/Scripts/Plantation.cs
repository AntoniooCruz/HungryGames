using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plantation : MonoBehaviour
{
    public enum PlantType { Wheat, Beans, Grain };
    public Sprite[] plantProgress = new Sprite[4];
    private bool[] enhancements = new bool[4];
    private PlantType type;
    private int heatResitance = 0;
    private int coldResistance = 0;
    private int floodResistance = 0;
    private int pestResistance = 0;
    private int droughtsResistance = 0;
    private int timeToCollect = 0;
    private int id;

    Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();

        //Temporary
        image.sprite = plantProgress[0];
        
    }
    public Plantation(PlantType type)
    {
        this.type = type;
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
}

