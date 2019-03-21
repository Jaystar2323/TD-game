using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{

    public GameObject poisonEffect;
   // public GameObject slowEffect;
    private float durationP;
    private float durationS;

    // Update is called once per frame
    void Start()
    {
        poisonEffect.SetActive(false);
      //  slowEffect.SetActive(false);
    }
    void Update()
    {
        if(durationP <= 0)
        {
            durationP = 0;
            poisonEffect.SetActive(false);
        }
        else
        {
            durationP -= Time.deltaTime;
        }
        if (durationS <= 0)
        {
            durationS = 0;
           // slowEffect.SetActive(false);
        }
        else
        {
            durationS -= Time.deltaTime;
        }

    }

    public void activePoison(float dur)
    {
        poisonEffect.SetActive(true);
        durationP = dur;
    }
    public void activeSlow(float dur)
    {
       // slowEffect.SetActive(true);
        durationS = dur;
    }
    public bool isPoisonActive()
    {
        if(durationP > 0)
        {
            return true;
        }
        return false;
    }
}
