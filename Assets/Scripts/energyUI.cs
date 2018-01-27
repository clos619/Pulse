using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyUI : MonoBehaviour {
    public Slider energySlider;
    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        energySlider = _energy;
    }
    void getEnergy()
    {
        return _energy;
    }
}
