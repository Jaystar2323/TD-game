using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPoison : Turret
{
    private float rotate = 0;
    public GameObject deathEffect;
    void UpdateTarget()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        //foreach(GameObject enemy in enemies)
        //{
        //    enemies.Remove(enemy);
        //}
        enemies = new ArrayList();
        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
                enemies.Add(enemy);
            }
        }
    
    }

    void Update()
    {
        //add constant rotation
        //partRotate.rotation = Quaternion.Euler();
        Vector3 rotations = new Vector3(0, rotate + (turnSpeed * Time.deltaTime), 0);
        //Debug.Log(partRotate.rotation.y);
        if(partRotate.rotation.y <= 0)
        {
            rotate = 0;
        }
        partRotate.transform.Rotate(rotations, turnSpeed, Space.World);
        if (fireCountdown <= 0)
        {
            foreach (GameObject enemy in enemies)
            {

                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().damageEnemy(damage);
                    if(enemy.GetComponent<Enemy>().health <= 0)
                    {
                        GameObject effectIns = Instantiate(deathEffect, enemy.transform.position, enemy.transform.rotation);
                        Destroy(effectIns, 5);
                    }
                    enemy.GetComponent<ParticleEffects>().activePoison(3);
                }


            }
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
        //partRotate.rotation = Quaternion.Euler(0f, partRotate.rotation.y + turnSpeed, 0f);
    }
    

}
