
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Optional")]
    public GameObject turret;
    [Header("cac")]
    public Vector3 posiitonOffset;

   
    private Renderer rend;

    public Color notEnoughMoneyColor;
    public Color  hovercolor;
    private Color startcolor;
    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuldPosition()
    {
        return transform.position + posiitonOffset;
    }
    private void OnMouseDown()//khi chuột nhấn xuống gameobject 
    {
        if (EventSystem.current.IsPointerOverGameObject())// nếu người chơi chỉ vào ui thì trả về true 
        {
            return;
        }
        if (!buildManager.CanBuild) {
            return;
        }
        if (turret != null)
        {
            Debug.Log("buoi");
            return;
        }

        //build a turret
        buildManager.BuildturretOn(this);
    }
    private void OnMouseEnter()
    {
       
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.HasMoney) {

            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        
    }
    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
