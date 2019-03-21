using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 400;
    private float timer = 0;
    private static bool levelEnded = false;

    void Start()
    {
        money = startMoney;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0)
        {

            if (levelEnded)
            {
                return;
            }

            if(money >= 2000)
            {
                money += 4;
            }
            if(money >= 1500)
            {
                money += 3;
            }
            if(money >= 1000)
            {
                money += 2;
            }
            if(money >= 500)
            {
                money += 1;
            }
           
            money += 5;

            
            timer = 0;
        }
    }
    public static void levelEnd()
    {
        levelEnded = true;
    }
}
