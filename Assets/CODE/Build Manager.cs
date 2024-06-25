
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("nhieu hon 1 buildmanager");
            return;
        }
        instance = this; // chỉ lấy code đầu tiền làm biến chính 

    }




    //public GameObject standardTurretPrefabl;
    //public GameObject missileLuncherPrefabl;



    public TuretBluesprint turretToBuild;
    public bool CanBuild {  get { return turretToBuild != null; } }
    // nếu turretToBuild != null thì CanBuild = True else CanBuild = False 
    // khi biến thây đổi thì lập tức nhận đc , giống như Change trong roblox studio 
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; ; } }

    public void BuildturretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("deo du tien ");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuldPosition(), Quaternion.identity);
        node.turret = turret;
    }
    public void SelectTurretToBuild(TuretBluesprint turret)
    {
        turretToBuild = turret;
    }
}
