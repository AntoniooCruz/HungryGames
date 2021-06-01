using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowButtons : MonoBehaviour
{
    public Button StatsButton;
    public Button UpgradeButton;
    public Button SelectButton;
    private bool alive = true;

    public void ToggleButtons()
    {
        if(alive)
        {
            StatsButton.gameObject.SetActive(!StatsButton.IsActive());
            if(!gameObject.GetComponent<VisualPlantation>().choosePlantation)
                UpgradeButton.gameObject.SetActive(!UpgradeButton.IsActive());
            else
                SelectButton.gameObject.SetActive(!SelectButton.IsActive());
        }
        
    }

    public void KillPlant()
    {
        alive = false;
    }

}
