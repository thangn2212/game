using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MoneyUI : MonoBehaviour
{
    public Text monyText;

  
    void Update()
    {
        monyText.text = "$" + PlayerStats.Money.ToString();
    }
}
