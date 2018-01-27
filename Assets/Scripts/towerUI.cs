using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerUI : MonoBehaviour {
    public int towersTotal = 3;
    public int towersFound = null;
    bool foundOne;
	// Use this for initialization
	void Start () {
        towersFound = 0;
        

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
}
