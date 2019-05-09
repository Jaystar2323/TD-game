using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOptions : MonoBehaviour {

    public static Turret turret;
    public static bool isDamageTurret = false;
    public Text upgradeCostText;
    public Text sellAmountText;
    public Text damageText;
    public Text fireRateText;
    public Text rangeText;
    public Text multiplierText;
    public Shop shop;
    private int upgradeCost;
    private int sellMoney;

    
	void Update () {
        //gameObject.SetActive(active);
        if (turret == null)
        {
            return;
        }
        if (turret.getUpgradeTier() == 0)
        {
            upgradeCost = turret.upgradeCost;
            sellMoney = (int)(turret.upgradeCost/2 * .75);
            upgradeCostText.text = "$" + turret.upgradeCost.ToString();
            sellAmountText.text = "$" + (upgradeCost/2*.75).ToString();

        }
        else if (turret.getUpgradeTier() == 1)
        {
            sellMoney = (int)(turret.upgradeCost / 2 * .75) + (int)(turret.upgradeCost * .75);
            //Debug.Log(upgradeCost);
            upgradeCost = turret.upgradeCost * 2;
            upgradeCostText.text = "$" + (turret.upgradeCost * 2).ToString();
            sellAmountText.text = "$" + ((int)(turret.upgradeCost / 2 * .75) + (int)(turret.upgradeCost * .75)).ToString();
        }
        else
        {
            sellMoney = (int)((turret.upgradeCost/2 *.75) + (int) + (turret.upgradeCost * 2 * .75)) + (int)(turret.upgradeCost * .75);
            upgradeCostText.text = "max";
            sellAmountText.text = "$"+ ((int)((turret.upgradeCost / 2 * .75) + (int)(turret.upgradeCost * 2 * .75) + (int)(turret.upgradeCost * .75))).ToString();
        }

        damageText.text = "Damage: " + Mathf.Round(turret.damage).ToString();
        fireRateText.text = "Fire Rate: " + turret.fireRate.ToString();
        rangeText.text = "Range: " + turret.range.ToString();
        if (isDamageTurret)
        {
            multiplierText.gameObject.SetActive(true);
            multiplierText.text = "Multiplier: " + turret.GetComponent<TurretDamageBoost>().damageMultiplier;
        }
        else
        {
            if(multiplierText != null)
            {
                multiplierText.gameObject.SetActive(false);
            }
        }
        

	}

    public static void setTurret(GameObject turret)
    {
        TowerOptions.turret = turret.GetComponent<Turret>();
        if(turret.GetComponent<TurretDamageBoost>() != null)
        {
            isDamageTurret = true;
        }
        else
        {
            isDamageTurret = false;
        }
    }

    public void UpgradeTower()
    {
        if (turret.getUpgradeTier() < 3 && PlayerStats.money >= upgradeCost)
        {
            PlayerStats.money -= upgradeCost;
            Scoring.addTowerValue((int)(upgradeCost * .75f));
            turret.upgrade();
            close();
            
        }
    }

    public void SellTurret()
    {
        PlayerStats.money += sellMoney;
        Scoring.addTowerValue(-sellMoney);
        Destroy(turret.gameObject);
        close();
        
    }

    public void close()
    {
        gameObject.SetActive(false);
        BuildManager.setVisible(false);
    }
    

}
