using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiverUI : MonoBehaviour
{

    public Text livesText;

  
   

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
