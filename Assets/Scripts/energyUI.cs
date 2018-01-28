using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class energyUI : MonoBehaviour {
    public Scrollbar energySlider;
    public PlayerStats playerstats;


    // Use this for initialization
    void Start () {
        Debug.Log(energySlider);
        energySlider.size = playerstats.Energy/1500;
      
  
        
    }
	
	// Update is called once per frame
	void Update () {
        
        energySlider.size = playerstats.Energy/1500;
        

        
       

    }
    
}
