using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamageBoost : Turret
{
    // Start is called before the first frame update
    ArrayList turrets;
    public float damageMultiplier;
    public float upgradeMultiplierIncrease;
    


    void UpdateTarget()
    {
        GameObject[] allTurrets = GameObject.FindGameObjectsWithTag("Turret");
        turrets = new ArrayList();
        foreach(GameObject turret in allTurrets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turret.transform.position);
            if(distanceToEnemy <= range)
            {
                turrets.Add(turret);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<AttackDmgEffect>().resetTimer(damageMultiplier);
            //turret.AddComponent<>
        }
    }

    public void Upgrade()
    {
        if(getUpgradeTier() == 1)
        {
            damageMultiplier += upgradeMultiplierIncrease;
        }
        if(getUpgradeTier() == 2)
        {
            damageMultiplier += 2 * (upgradeMultiplierIncrease);
        }
    }
}
