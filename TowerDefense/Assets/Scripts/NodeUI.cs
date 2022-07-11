using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public Text upgradeCost;
    public GameObject ui;
    public Button upgradeButton;

    public void SetTarget (Node _target){

        this.target = _target;

        transform.position = target.transform.position;

        if(!target.isUpgraded){
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        } else {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);

    }

    public void Hide(){
        ui.SetActive(false);
    }

    public void Upgrade(){
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
