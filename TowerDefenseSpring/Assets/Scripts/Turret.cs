using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public int upgradeCost;
    public float damage = 2;
    public float upgradeDmgIncrease = 1;
    public float upgradeFireRateIncrease = 0;
    public float upgradeRangeIncrease = 0;
    protected float fireCountdown = 0f;
    private int upgradeTier = 0;
    protected float baseDamage;
    //public bool damageInRange = false;


    [Header("Unity Setup")]
    public string enemyTage = "Enemy";
    public Transform partRotate;
    public float turnSpeed = 10f;
    public GameObject tier1;
    public GameObject tier2;
    public GameObject tier3;

    public GameObject bullet;
    public Transform firePoint;
    protected ArrayList enemies = new ArrayList();
    


	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        baseDamage = damage;
        tier1.SetActive(true);
	}
	
    void UpdateTarget()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        //if (damageInRange)
        //{
        //    //foreach(GameObject enemy in enemies)
        //    //{
        //    //    enemies.Remove(enemy);
        //    //}
        //    enemies = new ArrayList();
        //    foreach (GameObject enemy in allEnemies)
        //    {
        //        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
        //        if (distanceToEnemy <= range)
        //        {
        //            enemies.Add(enemy);
        //        }
        //    }
        //    return;
        //}

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            //Debug.Log("Target Found");
        }
        else
        {
            target = null;
        }

    }

	// Update is called once per frame
	void Update () {
        //if (damageInRange)
        //{
        //    if(fireCountdown <= 0)
        //    {
        //        foreach (GameObject enemy in enemies)
        //        {
              
        //            if(enemy != null)
        //            {
        //                enemy.GetComponent<Enemy>().damageEnemy(damage);
        //            }


        //        }
        //        fireCountdown = 1f / fireRate;
        //    }

        //    fireCountdown -= Time.deltaTime;
        //    partRotate.rotation = Quaternion.Euler(0f, partRotate.rotation.y + turnSpeed, 0f);

        //    return;
        //}
		if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

	}

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bulletS = bulletObject.GetComponent<Bullet>();
        if(bulletS != null)
        {
            bulletS.Seek(target);
            bulletS.setDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public int getUpgradeTier()
    {
        return upgradeTier;
    }
    public void upgrade()
    {
        upgradeTier += 1;
        damage += upgradeDmgIncrease;
        baseDamage += upgradeDmgIncrease;
        fireRate += upgradeFireRateIncrease;
        range += upgradeRangeIncrease;
        if (upgradeTier == 1)
        {
            tier1.SetActive(false);
            tier2.SetActive(true);
        }
        else
        {
            tier2.SetActive(false);
            tier3.SetActive(true);
        }
    }

    public void increaseDamage(float multiplier)
    {
        damage = baseDamage * multiplier;
        Debug.Log("Incease");
    }
    public void damageReset()
    {
        damage = baseDamage;
    }

}
