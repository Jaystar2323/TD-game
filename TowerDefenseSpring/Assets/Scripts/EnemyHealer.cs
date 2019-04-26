using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealer : Enemy
{
    private float timeSinceHit = 0;
    private float healTick = 0;

    public override void doUpdate()
    {
        if (timeSinceHit >= 3.5 && health != maxHealth)
        {
            //regen effect
            effects.activeHeal();
            healTick += Time.deltaTime;
            if(healTick >= 1)
            {
                this.health += 8;
                healTick = 0;
            }
            if(this.health >= this.maxHealth)
            {
                this.health = maxHealth;
            }
        }
        else
        {
            effects.deactivateHeal();
        }

        timeSinceHit += Time.deltaTime;

    }

    public override void onHit()
    {
        timeSinceHit = 0;
    }
}
