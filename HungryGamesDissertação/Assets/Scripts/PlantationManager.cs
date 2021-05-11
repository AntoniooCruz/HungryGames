using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantationManager : MonoBehaviour
{
    public GameObject[] plantationsObjects = new GameObject[3];
    public static List<Plantation> plantations = new List<Plantation>();
    public Sprite[] BeansProgress = new Sprite[4];
    public Grid grid;
    public int currentPlant = 0;

    private void Start()
    {
        grid = new Grid(2, 2,133);
    }

    public void addPlantation(Plantation.PlantType type)
    {
        Plantation plantation = new Plantation(type);
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
                    crop = Instantiate(plantationsObjects[0], grid.getPosition(plant.getId()) + new Vector3(300, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    break;
                case Plantation.PlantType.Grain:
                    crop = Instantiate(plantationsObjects[1], grid.getPosition(plant.getId()) + new Vector3(300, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    break;
                case Plantation.PlantType.Wheat:
                    crop = Instantiate(plantationsObjects[2], grid.getPosition(plant.getId()) + new Vector3(300, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    break;
                default:
                    crop = Instantiate(plantationsObjects[0], grid.getPosition(plant.getId()) + new Vector3(300, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<VisualPlantation>().plantation = plantations[plant.getId()];
                    plantations[plant.getId()].progressBar = crop.transform.GetChild(3).GetComponent<ProgressBar>();
                    crop.GetComponent<VisualPlantation>().plantation.updateSprite();
                    break;
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

    }




}
