using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class energy : MonoBehaviour {

    public int startingEnergy = 1500;
    public int currentEnergy;
    public Slider energySlider;
    bool isMoving;
    public PlayerStats PlayerStats;
	// Use this for initialization
	void Start () {
        currentEnergy = startingEnergy;
	}
	
	// Update is called once per frame
	void Update () {
        loseEnergy();

	}
    void loseEnergy()
    {
        if(isMoving == true)
        {
            currentEnergy = currentEnergy - 5;
        }
        
        
        
    }

}
