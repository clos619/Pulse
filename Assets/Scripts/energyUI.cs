using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class energyUI : MonoBehaviour {
    public Slider energySlider;
    public PlayerStats playerstats;

    // Use this for initialization
    void Start () {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        energySlider.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        energySlider.value = playerstats.Energy;
    }
    
}
