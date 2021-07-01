using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = "+" + GameMaster.GM.displayResistance.resistances[i].ToString();
        }
    }

}
