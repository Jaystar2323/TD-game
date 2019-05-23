using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint cannonTurret;
    public TurretBlueprint poisonTurret;
    public TurretBlueprint damageIncrease;
    public TurretBlueprint slowTurret;
    BuildManager buildManager;

    public void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Purchased");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectCannonTurret()
    {
        Debug.Log("Cannon Purchased");
        buildManager.SelectTurretToBuild(cannonTurret);
    }
    public void SelectPoisonTurret()
    {
        Debug.Log("Poison Turret Purchased");
        buildManager.SelectTurretToBuild(poisonTurret);
         
    }
    public void SelectDamageIncrease()
    {
        Debug.Log("Damage Increase Turret Purchased");
        buildManager.SelectTurretToBuild(damageIncrease);
    }
    public void SelectSlowTurret()
    {
        Debug.Log("Slow Turret Purchased");
        buildManager.SelectTurretToBuild(slowTurret);
    }

}
