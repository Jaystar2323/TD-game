using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoney;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;
    
    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //BuildManager.setVisible(false);
            return;
        }
        if (!buildManager.CanBuild)
        {
           // BuildManager.setVisible(false);

            return;
        }

        if(turret != null)
        {
            //Debug.Log("Can't Build there");
            TowerOptions.setTurret(turret);
            BuildManager.setVisible(true);
            return;
        }
       // BuildManager.setVisible(false);
        buildManager.BuildTurretOn(this);

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

	void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            rend.material.color = hoverColor;
        }
        if (buildManager.CanBuild && buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoney;
        }
       
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        
    }

}
