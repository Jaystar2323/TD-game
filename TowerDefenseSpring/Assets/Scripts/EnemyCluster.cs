using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCluster : MonoBehaviour {

    // Use this for initialization
    private int wavepointIndex = 0;
    protected Transform target;
    public int speed;
    void Start()
    {
        //Debug.Log(Waypoints.points[0]);
        target = Waypoints.points[0];

    }

    void Update()
    {
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        doUpdate();

    }
    void GetNextWaypoint()
    {

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            WaveSpawner.loseLives(livesLostCount());
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public virtual void doUpdate()
    {
        return;
    }

    public virtual int livesLostCount()
    {
        return transform.childCount;
    }
}
