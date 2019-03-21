using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0;
    public GameObject impactEffect;
    public Material defaultMaterial;
    public bool useDefaultMaterial = true;
    private float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);

	}

    void HitTarget()
    {
        //impactEffect
        if(!useDefaultMaterial)
        {
            impactEffect.GetComponent<ParticleSystemRenderer>().material = target.GetComponent<MeshRenderer>().material;
        }
        else
        {
            impactEffect.GetComponent<ParticleSystemRenderer>().material = defaultMaterial;
        }

        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5);

        if(explosionRadius > 0f)
        {
            Explode();
            Damage(target);
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        //Destroy(enemy.gameObject);
        //if (enemy.name == "Enemy(Clone)")
        //{
        //    PlayerStats.money += 5;
        //}else if (enemy.name == "EnemyFast(Clone)")
        //{
        //    PlayerStats.money += 10;
        //}
        if (explosionRadius > 0f)
        {
            enemy.gameObject.GetComponent<Enemy>().damageEnemy(damage/2);
        }
        else
        {
            enemy.gameObject.GetComponent<Enemy>().damageEnemy(damage);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    public void setDamage(float dmg)
    {
        damage = dmg;
    }
}
