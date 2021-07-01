using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text += GameMaster.GM.getTurn();
    }

}
