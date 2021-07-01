using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }

    private void Awake()
    {
        Instance = this;
        Load();
        DontDestroyOnLoad(gameObject);

        Debug.Log(SaveHelper.Serialize<List<Plantation>>(PlantationManager.plantations));
    }

    public void Save()
    {
        PlayerPrefs.SetString("save",SaveHelper.Serialize<List<Plantation>>(PlantationManager.plantations));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            GameMaster.GM = SaveHelper.Deseriazlize<GameMaster>(PlayerPrefs.GetString("save"));
        } 
    }

}
