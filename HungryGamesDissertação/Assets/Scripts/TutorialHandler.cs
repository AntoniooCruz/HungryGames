using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    public int currentTutorial = 0;
    public Button backButton;
    public Button nextButton;
    public Button startButton;

    public void nextTutorial()
    {
        if (currentTutorial == 0)
            backButton.gameObject.SetActive(true);
        currentTutorial++;
        transform.GetChild(currentTutorial - 1).gameObject.SetActive(false);
        transform.GetChild(currentTutorial).gameObject.SetActive(true);
        if(currentTutorial == 13)
        {
            startButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
    }

    public void backTutorial()
    {
        if (currentTutorial == 13)
        {
            startButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }

        if (currentTutorial == 1)
            backButton.gameObject.SetActive(false);
        currentTutorial--;
        transform.GetChild(currentTutorial + 1).gameObject.SetActive(false);
        transform.GetChild(currentTutorial).gameObject.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene(0);
    }
}
