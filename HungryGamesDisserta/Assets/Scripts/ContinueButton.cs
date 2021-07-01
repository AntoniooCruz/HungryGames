using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlantationManager.plantations.Count == 0)
            this.gameObject.SetActive(false);
    }

}
