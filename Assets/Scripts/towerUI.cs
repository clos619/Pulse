using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerUI : MonoBehaviour {
    public int towersTotal = 3;
    public int towersFound = 0;
    public bool foundOne = true;
    public string Towers;
    public Text Towers_txt;
    public Text totalTowers;
    
    
	// Use this for initialization
	void Start () {
        towersFound = 0;
        foundOne = false;
        settowersFound();
        totalTowers.text = "Total Towers: " + towersTotal;
        
	}
	
	// Update is called once per frame
	void Update () {
        foundTower();
	}
    void foundTower()
    {
        if(foundOne == true)
        {
            towersFound = towersFound + 1;
        }
    }
    void settowersFound()
    {
        Towers_txt.text = "Towers Found: " + towersFound;
    }
}
