using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDmgEffect : MonoBehaviour
{
    private float timer;
    public Turret turret;
    private float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < 1)
        {
            //this.GetComponent<Turret>().damage *=;
            turret.increaseDamage(multiplier);
        }
        else
        {
            turret.damageReset();
        }
    }

    public void resetTimer(float multiplier)
    {
        timer = 0;
        this.multiplier = multiplier;
    }

}
