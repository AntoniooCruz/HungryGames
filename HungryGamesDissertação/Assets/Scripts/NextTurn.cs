using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurn : MonoBehaviour
{
    public void NextGameTurn()
    {
        GameMaster.GM.nextTurn();
    }
}
