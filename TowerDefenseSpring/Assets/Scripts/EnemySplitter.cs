﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplitter : EnemyCluster
{
    private GameObject enemySplit;
    private GameObject enemySplitter;
    private bool paid = false;
    void Start()
    {
        enemySplit = transform.GetChild(1).gameObject;
        enemySplitter = transform.GetChild(0).gameObject;
        enemySplit.SetActive(false);
        target = Waypoints.points[0];
        maxSpeed = speed;
    }
    //public override void KillEnemy()
    //{
    //    //Debug.Log("Spawn Split");
    //    //enemySplit.GetComponent<Enemy>().setWaypointIndex(this.getWayPointIndex());
    //    //Instantiate(enemySplit, transform.position, transform.rotation).GetComponent<Enemy>();
    //    //enemy.setWaypointIndex(this.getWayPointIndex());
    //    //base.KillEnemy();
    //}
    public override void doUpdate()
    {
        //if(enemySplitter == null)
        //{
            
            
            
        //}
        //if(enemySplitter != null)
        //{
        //    Debug.Log("hi");
        //    //enemySplit.GetComponentInChildren<Enemy>().setWaypointIndex(enemySplitter.GetComponent<Enemy>().getWayPointIndex());
            
        //}
    }

    public override int livesLostCount()
    {
        if(enemySplitter == null)
        {
            return enemySplit.transform.childCount;
        }
        else
        {
            return 6;
        }
    }
    public void onDeath()
    {
        //Debug.Log("death");
        speed = 14;
        maxSpeed = 14;
        enemySplit.SetActive(true);
        PlayerStats.money += 26;
        foreach (Transform child in enemySplit.transform)
        {
            child.GetComponent<Enemy>().setWaypointIndex(enemySplitter.GetComponent<Enemy>().getWayPointIndex());
            //Debug.Log(enemySplitter.GetComponent<Enemy>().getWayPointIndex());
        }
    }

    public override void checkSlowEffect()
    {
        int count = 0;
        if(enemySplitter != null)
        {
            if(enemySplitter.GetComponent<Enemy>().getSlowDur() > 0)
            {
                speed = maxSpeed * .5f;
            }
            else
            {
                speed = maxSpeed;
            }
            return;
        }
        foreach (Transform enemy in enemySplit.transform)
        {
            if (enemy.GetComponent<Enemy>().getSlowDur() > 0)
            {
                speed = (maxSpeed * .5f);
                Debug.Log("work");

                break;
            }
            else
            {
                count++;
            }
            if (count == enemySplit.transform.childCount)
            {
                speed = maxSpeed;
            } 
        }
    }

}
