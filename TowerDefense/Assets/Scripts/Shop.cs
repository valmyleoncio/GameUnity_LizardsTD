using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint missiLauncher; 

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret(){
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret(){
        buildManager.SelectTurretToBuild(missiLauncher);
    }
}