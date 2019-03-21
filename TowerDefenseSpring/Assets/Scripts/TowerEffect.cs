using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEffect : MonoBehaviour {

    private GameObject tower;
    public Color tier1Color;
    public Color tier2Color;
    public Color tier3Color;
	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setTower(GameObject towerIn)
    {
        tower = towerIn;
    }
}
