using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class energyBoost : MonoBehaviour {

    public float boostEnergy = 100;
    public GameObject erg;
    public PlayerStats playerstats;
    public energyUI life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void onTriggerEvent(Collider erg)
    {
        if(erg.gameObject.CompareTag("Pick Up"))
        {
            erg.gameObject.SetActive(true);

            life.energySlider.size = playerstats.Energy + boostEnergy;

        }
    }
}
