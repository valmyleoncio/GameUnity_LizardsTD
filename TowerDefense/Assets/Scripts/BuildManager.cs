using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretBluePrint standardTurretPrefab; 
    public TurretBluePrint anotherTurretPrefab;
    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    private void Awake() {
        if(instance != null){
            Debug.LogError("More Than One BuildManager");
            return;
        }
        
        instance = this;
    }

    public bool CanBuild{ get { return turretToBuild == null; }}

    public void SelectedNode(Node node){

        if(selectedNode == node){
            DeselectNode();
            return;
        }
         
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBluePrint turret){
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretTobuild(){
        return turretToBuild;
    }
}
