using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public Sprite[] beansProgress = new Sprite[4];
    public Sprite[] cornProgress = new Sprite[4];
    public Sprite[] wheatProgress = new Sprite[4];
    public PlantationManager plantationManager;
    public DisplayResistance displayResistance;
    public DisplayUpgrades displayUpgrades;

    public int dnaPoints = 1000;
    public int populationPoints = 100;
    public int foodPoints = 200;
    public int deaths = 0;
    private int turn = 0;
 
    public ForecastHandler forecastHandler;

    void Awake()
    {
   
        if (GM == null)
            GM = this;
        else if (GM != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
 
    public void nextTurn()
    {
        turn++;
        foreach(Plantation plant in PlantationManager.plantations)
        {
            plant.nextTurn();
        }
        dnaPoints += 100;
        foodPoints -= populationPoints / 20;
        populationPoints += populationPoints / 15;
        if (foodPoints <= 0)
        {
            foodPoints = 0;
            deaths++;
            populationPoints--;
        }
        if (turn % 5 == 0)
        {
            forecastHandler.UpdateForecast();
        }

        if(deaths >= 5)
            SceneManager.LoadScene(7);
    }

    public int getTurn()
    {
        return turn;
    }

    public void newGame()
    {
        GM = new GameMaster();
        PlantationManager.plantations = new List<Plantation>();
    }
}