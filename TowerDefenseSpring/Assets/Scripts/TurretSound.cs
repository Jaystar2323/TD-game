using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSound : MonoBehaviour
{
    public AudioClip sound;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = sound;
    }

   
    public void playSoundEffect()
    {
        //Debug.Log("playing");
        GetComponent<AudioSource>().Play();
    }

}
