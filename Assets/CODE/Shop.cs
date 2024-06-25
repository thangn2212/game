using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TuretBluesprint standarTurret;
    public TuretBluesprint missileLaucher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
      
      
        buildManager.SelectTurretToBuild(standarTurret);
    }

    public void SelectMissileLuncher()
    {
     
        buildManager.SelectTurretToBuild(missileLaucher);
    }
}
