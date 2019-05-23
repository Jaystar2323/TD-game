using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public float health = 20f;
    protected Transform target;
    private int wavepointIndex = 0;
    protected float maxHealth;
    private float pTickCountdown;
    public bool canMove = true;
    public float healthMultiplier = 1.0f;
    public WaveSpawner waveSpawner;
    public ParticleEffects effects;
    public float targetLevel;
    private float slowDur = 0;
    private float maxSpeed;
  


    void Start()
    {
        //Debug.Log(Waypoints.points[0]);
        target = Waypoints.points[wavepointIndex];
        waveSpawner = GameObject.Find("GameControl").GetComponent<WaveSpawner>();
        health += waveSpawner.getWaveNumber() * healthMultiplier;
        maxHealth = health;
        effects = this.GetComponent<ParticleEffects>();
        targetLevel = 0;
        maxSpeed = speed;
        
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();

            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) <= 2f)
            {
                GetNextWaypoint();
                

            }
        }
        
        targetLevel = wavepointIndex - (Vector3.Distance(transform.position, target.position) / 100);
        doUpdate();

        if(slowDur > 0)
        {
            speed = (maxSpeed * .5f);
            slowDur -= Time.deltaTime;
        }
        if(slowDur <= 0)
        {
            slowDur = 0;
            speed = maxSpeed;
        }

    }

    void CheckEffects()
    {
        if (effects.isPoisonActive())
        {
            if(pTickCountdown <= 0)
            {
                pTickCountdown = 0.5f;
                health -= (maxHealth * 0.02f);
                //Damage enemy for 1.5% of max health
            }
            pTickCountdown -= Time.deltaTime;
        }
        else
        {
            pTickCountdown = 0.5f;
        }
    }

	void GetNextWaypoint()
    {

        if(wavepointIndex >= Waypoints.points.Length - 1)
        {

            WaveSpawner.loseLives(1);

            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    public void damageEnemy(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            if (this.name == "Enemy(Clone)")
            {
                PlayerStats.money += 14;
            }else if (this.name == "EnemyFast(Clone)")
            {
                PlayerStats.money += 18;
            }else if (this.name == "EnemyBig(Clone)" || this.name == "EnemyFast2(Clone)")
            {
                PlayerStats.money += 70;
            }else if (this.name == "EnemySmall" || this.name == "EnemySmall2")
            {
                PlayerStats.money += 10;
            }
            else if (this.name == "EnemySplitterSmall")
            {
                PlayerStats.money += 20;
            }
            else if (this.name == "EnemySplitting(Clone)")
            {
                PlayerStats.money += 26;
            }else if(this.name == "EnemyHealer(Clone)")
            {
                PlayerStats.money += 25;
            }
            onDeath();
            KillEnemy();
            Scoring.scoreKill(this);
        }
        onHit();
    }
    public void slowEffect()
    {
        slowDur = 3;
    }
    public virtual void onHit()
    {
        return;
    }
    public virtual void doUpdate()
    {
        return;
    }
    public virtual void KillEnemy()
    {
        Destroy(this.gameObject);
    }
    public float getTargetLevel()
    {
        return targetLevel;
    }
    public void setWaypointIndex(int index)
    {
        this.wavepointIndex = index;
        target = Waypoints.points[wavepointIndex];
        //Debug.Log(target);
    }
    public int getWayPointIndex()
    {
        return wavepointIndex;
    }
    public virtual void onDeath()
    {

    }
    public float getSlowDur()
    {
        return slowDur;
    }

}
