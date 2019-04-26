using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBars : MonoBehaviour
{
    private Enemy parentEnemy;
    public GameObject healthBar;
    private float maxHealth;
    private float healthBarInitSize;

    public Material greenMaterial;
    public Material yellowMaterial;
    public Material redMaterial;

    void Start()
    {
        this.parentEnemy = this.GetComponentInParent<Enemy>();
        this.maxHealth = parentEnemy.health;
        this.healthBarInitSize = this.transform.localScale.z;

        healthBar.GetComponent<MeshRenderer>().material = greenMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        float healthPercentage = parentEnemy.health / maxHealth;
        float healthBarValue = healthBarInitSize * healthPercentage;
        Vector3 currentSize = new Vector3(this.transform.localScale.x, this.transform.localScale.y, healthBarValue);
        this.transform.localScale = currentSize;
        //this.healthBar.transform.rotation = Quaternion.Euler(90f, parentEnemy.transform.rotation.y * -1 + 90, 0f);

        if(healthPercentage > .5)
        {
            healthBar.GetComponent<MeshRenderer>().material = greenMaterial;
        }
        if (healthPercentage <= .5 && healthPercentage > .25)
        {
            healthBar.GetComponent<MeshRenderer>().material = yellowMaterial;
        }
        if (healthPercentage <= .25)
        {
            healthBar.GetComponent<MeshRenderer>().material = redMaterial;
        }



    }
}
