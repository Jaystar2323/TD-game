using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{

    public GameObject poisonEffect;
    public GameObject healEffect;
   // public GameObject slowEffect;
    private float durationP;
    private float durationS;
    private bool healActive;
    private bool deactivateLight;
    private float pulseTime = 0;
    private int increase = 0;

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

        if(healEffect != null && healActive)
        {
            pulseTime += Time.deltaTime;
            if(pulseTime >= .1)
            {
               //ebug.Log("working");
                
                if (healEffect.GetComponent<Light>().intensity <= 0)
                {
                    increase = 1;
                    if (deactivateLight)
                    {
                        healActive = false;
                        return;
                    }
                }
                if (healEffect.GetComponent<Light>().intensity >= 10)
                {
                    increase = -1;
                }
                Debug.Log(increase);
                healEffect.GetComponent<Light>().intensity += increase;
                pulseTime = 0;
            }
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
    public void activeHeal()
    {
        //healEffect.SetActive(true);
        healActive = true;
        deactivateLight = false;
    }
    public void deactivateHeal()
    {
        //healEffect.SetActive(false);
        deactivateLight = true;
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
