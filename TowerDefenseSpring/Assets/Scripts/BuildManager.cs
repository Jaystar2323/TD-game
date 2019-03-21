using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private static bool active = false;
    public TowerOptions towerOptions;


    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one build manager");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject cannonTurretPrefab;
    public GameObject poisonTurretPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild {get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Scoring.addTowerValue((int)(turretToBuild.cost * .75));
        PlayerStats.money -= turretToBuild.cost;

        //GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);

        //Debug.Log("Money Left" + PlayerStats.money);

    }

    void Update()
    {
        towerOptions.gameObject.SetActive(active);
    }

    public static void setVisible(bool isActive)
    {
        active = isActive;
        //Debug.Log(active);
    }

}
