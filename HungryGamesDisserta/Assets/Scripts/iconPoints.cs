using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconPoints : MonoBehaviour
{
    private UnityEngine.UI.Text[] points = new UnityEngine.UI.Text[4];
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            points[i] = transform.GetChild(i).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        points[0].text = GameMaster.GM.dnaPoints.ToString();
        points[1].text = GameMaster.GM.populationPoints.ToString();
        points[2].text = GameMaster.GM.foodPoints.ToString();
        points[3].text = GameMaster.GM.deaths.ToString();
    }
}
