using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{

    public GameObject poisonEffect;
    public Animator healEffect;
    public Material healMaterial;
   // public GameObject slowEffect;
    private float durationP;
    private float durationS;
    private bool healActive;
    private bool deactivateLight;
    private float pulseTime = 0;
    private int increase = 0;

    void Start()
    {
        Debug.Log("hi");
        poisonEffect.SetActive(false);
        //if (healEffect != null)
        //{
        //    //healEffect.playbackTime = 0;
        //    healEffect.StopPlayback();
        //    Debug.Log(true);
        //}
        //healEffect.StopPlayback();
        healActive = false;
      //  slowEffect.SetActive(false);
    }
    void Update()
    {
        //if (!healActive && healEffect.play)
        //{
        //    healEffect.StopPlayback();
        //}
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
             //Debug.Log("update");
            //if (healEffect.playbackTime == 0)
            //{
            if (healActive && pulseTime >= 1)
            {
                Debug.Log("Works");
                healEffect.Play("HealingGlow", -1, 0f);
                pulseTime = 0;

            }
            if(deactivateLight && pulseTime == 0)
            {
                healActive = false;
            }


            //}
            //if (healEffect.playbackTime >= 0 && healEffect.playbackTime <= 1 && deactivateLight)
            //{
            //    healEffect.playbackTime = 0;
            //    healEffect.StopPlayback();
            //    healActive = false;
            //}
            pulseTime += Time.deltaTime;
            //if(pulseTime >= .1)
            //{
            //    //ebug.Log("working");
            //    Debug.Log(healMaterial.);
            //    if (healEffect.GetComponent<Light>().intensity <= 0)
            //    {
            //        increase = 2;
            //        if (deactivateLight)
            //        {
            //            healActive = false;
            //            return;
            //        }
            //    }
            //    if (healEffect.GetComponent<Light>().intensity >= 20)
            //    {
            //        increase = -2;
            //    }
            //    Debug.Log(increase);
            //    healEffect.GetComponent<Light>().intensity += increase;
            //    pulseTime = 0;
            //}

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
