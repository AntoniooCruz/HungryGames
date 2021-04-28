using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantationManager : MonoBehaviour
{
    public GameObject[] plantationsObjects = new GameObject[3];
    public static List<Plantation> plantations = new List<Plantation>();
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

        // Do your code here to assign game objects
        //GameObject crop = Instantiate(plantationsObjects[0], grid.returnFreePosition() + new Vector3(150, 150), Quaternion.Euler(0, 0, 0));
        //crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
        //Plantation plantation = new Plantation(Plantation.PlantType.Beans);
        //crop.GetComponent<Plantation>().setId(0);
        //plantation.setId(0);
        foreach (var plant in plantations)
        {
            GameObject crop;
            switch (plant.getType())
            {
                case Plantation.PlantType.Beans:
                    crop = Instantiate(plantationsObjects[0], grid.returnFreePosition() + new Vector3(150, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<Plantation>().setId(plant.getId());
                    break;
                case Plantation.PlantType.Grain:
                    crop = Instantiate(plantationsObjects[1], grid.returnFreePosition() + new Vector3(150, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<Plantation>().setId(plant.getId());
                    break;
                case Plantation.PlantType.Wheat:
                    crop = Instantiate(plantationsObjects[2], grid.returnFreePosition() + new Vector3(150, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<Plantation>().setId(plant.getId());
                    break;
                default:
                    crop = Instantiate(plantationsObjects[0], grid.returnFreePosition() + new Vector3(150, 150), Quaternion.Euler(0, 0, 0));
                    crop.transform.SetParent(GameObject.FindGameObjectWithTag("Crops").transform, false);
                    crop.GetComponent<Plantation>().setId(plant.getId());
                    break;
            }
        }
    }




}
