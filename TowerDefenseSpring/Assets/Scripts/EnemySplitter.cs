using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplitter : EnemyCluster
{
    private GameObject enemySplit;
    private GameObject enemySplitter;
    void Start()
    {
        enemySplit = transform.GetChild(1).gameObject;
        enemySplitter = transform.GetChild(0).gameObject;
        enemySplit.SetActive(false);
        target = Waypoints.points[0];
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
        if(enemySplitter == null)
        {
            enemySplit.SetActive(true);
            speed = 14;
        }
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


}
