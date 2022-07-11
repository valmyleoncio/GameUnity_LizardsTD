using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverColor;
    private Color startColor;
    private Renderer rend;
    BuildManager buildManager;
    public GameObject turret;
    public TurretBluePrint turretBluePrint;
    public bool isUpgraded = false;

    void Start() 
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager =  BuildManager.instance;
    }

    void OnMouseEnter() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild)
            return;
            
        rend.material.color = hoverColor.color;
        
    }

    void OnMouseExit() 
    {
        rend.material.color = startColor;
    }

    private void OnMouseUpAsButton() {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null){
            buildManager.SelectedNode(this);
            return; 
        }

        if (buildManager.CanBuild)
            return;
        
        BuildTurret(buildManager.GetTurretTobuild());  
    }

    void BuildTurret(TurretBluePrint blueprint){
        if(PlayerStats.Money < blueprint.cost){
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject) Instantiate(blueprint.prefab, transform.position + blueprint.prefab.transform.position, transform.rotation);
        turret = _turret;

        turretBluePrint = blueprint;

    }

    public void UpgradeTurret(){
        if(PlayerStats.Money < turretBluePrint.upgradeCost){
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgradeCost;
        
        Destroy(turret);

        GameObject _turret = (GameObject) Instantiate(turretBluePrint.upgradePrefab, transform.position + turretBluePrint.prefab.transform.position, transform.rotation);
        turret = _turret;

        isUpgraded = true;

    }

}
