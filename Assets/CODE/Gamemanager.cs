using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    private bool GameEnde = false;
     void Update()
    {
        if (GameEnde)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }    
    }


    void EndGame()
    {
        GameEnde = true;
        Debug.Log("Game over");
    }
}
