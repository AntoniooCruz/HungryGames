using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowButtons : MonoBehaviour
{
    public Button StatsButton;
    public Button UpgradeButton;

    public void ToggleButtons()
    {
        StatsButton.gameObject.SetActive(!StatsButton.IsActive());
        UpgradeButton.gameObject.SetActive(!UpgradeButton.IsActive());
    }

}
