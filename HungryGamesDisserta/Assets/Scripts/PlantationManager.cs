using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantationManager : MonoBehaviour
{
    public GameObject[] plantationsObjects = new GameObject[4];
    public static List<Plantation> plantations = new List<Plantation>();
    public Sprite[] BeansProgress = new Sprite[4];
    public Grid grid;
    private int currentPage = 0;
    public int currentPlant = 0;
    public bool choosingPlantation = false;
    public int plantPage = 0;

    private void Start()
    {
        grid = new Grid(2, 2,145);
        GameObject crop;
        for(int i = 2; i >= plantations.Count % 3; i--)
        {
            crop = Instantiate(plantationsObjects[3], grid.getPosition(i) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
            crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
        }
        
    }

    public void addPlantation(Plantation.PlantType type)
    {
        Plantation plantation = new Plantation(type);
        plantation.setId(plantations.Count);
        plantations.Add(plantation);
    }

    public void addPlantation(Plantation plantation)
    {
        plantation.setId(plantations.Count);
        plantations.Add(plantation);
    }

    public void instantiatePlantations()
    {
        StartCoroutine(InitCoroutine());
    }

    IEnumerator InitCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        foreach (var plant in plantations)
        {
            GameObject crop;
            
            switch (plant.getType())
            {
                case Plantation.PlantType.Beans:
                    crop = Instantiate(plantationsObjects[0], grid.getPosition(plant.getId() % 3) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    crop.GetComponent<VisualPlantation>().choosePlantation = choosingPlantation;
                    crop.SetActive(false);
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    if (!plantations[plant.getId()].isAlive())
                        plantationDied(plant.getId());
                    break;
                case Plantation.PlantType.Corn:
                    crop = Instantiate(plantationsObjects[1], grid.getPosition(plant.getId() % 3) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    crop.GetComponent<VisualPlantation>().choosePlantation = choosingPlantation;
                    crop.SetActive(false);
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    if (!plantations[plant.getId()].isAlive())
                        plantationDied(plant.getId());
                    break;
                case Plantation.PlantType.Wheat:
                    crop = Instantiate(plantationsObjects[2], grid.getPosition(plant.getId() % 3) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    crop.GetComponent<VisualPlantation>().choosePlantation = choosingPlantation;
                    crop.SetActive(false);
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    if (!plantations[plant.getId()].isAlive())
                        plantationDied(plant.getId());
                    break;
                default:
                    crop = Instantiate(plantationsObjects[0], grid.getPosition(plant.getId() % 3) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    crop.GetComponent<VisualPlantation>().choosePlantation = choosingPlantation;
                    crop.SetActive(false);
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    if (!plantations[plant.getId()].isAlive())
                        plantationDied(plant.getId());
                    break;
            }
        }

        activatePlantPage(plantPage);
        

    }

    public void activatePlantPage(int page)
    {
        for(int j = 0; j < plantations.Count; j++)
        {
            GameObject.FindGameObjectWithTag("Crops").transform.GetChild(j).gameObject.SetActive(false);
        }
        if(plantations.Count > 0)
        {
            int amount = 3;
            bool emptyPlantation = false;
            if(plantations.Count / 3 == page)
            {
                amount = plantations.Count % 3;
                if (amount == 0)
                    amount = 3;
                emptyPlantation = true;
            }
            

            for (int i = page * 3; i < (amount + page * 3); i++)
            {
                GameObject.FindGameObjectWithTag("Crops").transform.GetChild(i).gameObject.SetActive(true);
            }

            if (emptyPlantation)
            {
                GameObject emptyCrop;
                if (plantations.Count % 3 != 0 && plantations.Count > 0 && !choosingPlantation)
                {
                    for (int i = 2; i >= (plantations.Count - 3 * page) % 3; i--)
                    {
                        emptyCrop = Instantiate(plantationsObjects[3], grid.getPosition(i) + new Vector3(439, 290), Quaternion.Euler(0, 0, 0));
                        emptyCrop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    }
                }
            } else
            {
                for (int i = plantations.Count; i < GameObject.FindGameObjectWithTag("Crops").transform.childCount; i++)
                {
                    GameObject.FindGameObjectWithTag("Crops").transform.GetChild(i).gameObject.SetActive(false);
                }
            }


        }
    }

    public void readyPlantationHarvest(int id)
    {
        GameObject crops = GameObject.FindGameObjectWithTag("Crops");
        crops.transform.GetChild(id).GetChild(4).gameObject.SetActive(true);
   
    }

    public void plantationDied(int id)
    {
        GameObject crops = GameObject.FindGameObjectWithTag("Crops");
        crops.transform.GetChild(id).GetChild(4).gameObject.SetActive(false);
        crops.transform.GetChild(id).GetChild(5).gameObject.SetActive(true);
        crops.transform.GetChild(id).GetChild(3).transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 16, 16, 255);
        crops.transform.GetChild(id).GetComponent<Button>().interactable = false;
        crops.transform.GetChild(id).GetComponent<HideShowButtons>().KillPlant();

    }

    public void plantationReset(int id)
    {
        GameObject crops = GameObject.FindGameObjectWithTag("Crops");
        crops.transform.GetChild(id).GetChild(5).gameObject.SetActive(true);
        crops.transform.GetChild(id).GetChild(4).gameObject.SetActive(false);
    }

    public void plantationAlive(int id)
    {
        GameObject crops = GameObject.FindGameObjectWithTag("Crops");
        crops.transform.GetChild(id).GetChild(5).gameObject.SetActive(false);
    }




}
