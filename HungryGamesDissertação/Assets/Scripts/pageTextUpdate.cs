using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pageTextUpdate : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = (GameMaster.GM.plantationManager.plantPage + 1) + " / " + ((PlantationManager.plantations.Count - 1) / 3 + 1);
    }
}
