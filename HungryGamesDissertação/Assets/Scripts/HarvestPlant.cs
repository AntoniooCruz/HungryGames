using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestPlant : MonoBehaviour
{
  public void HarvestPlantation()
    {
        gameObject.transform.parent.gameObject.GetComponent<VisualPlantation>().plantation.harvestPlantation();
        gameObject.SetActive(false);
    }
}
