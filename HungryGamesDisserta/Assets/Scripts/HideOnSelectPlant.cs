using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnSelectPlant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameMaster.GM.plantationManager.choosingPlantation)
            gameObject.SetActive(false);
    }

  
}
