using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class energyUI : MonoBehaviour {
    public Scrollbar energySlider;
    public PlayerStats playerstats;

    private int halfEnergy;
    private int quarterEnergy;

    private Color flashStart = Color.red;
    private Color flashEnd = Color.black;
    private float flashDuration = 0f;
    const float FLASH_TIME = 0.5f; // time to change from flashStart color to flashEnd color.

    // Use this for initialization
    void Start () {
        Debug.Log(energySlider);
        energySlider.size = playerstats.Energy/playerstats.MaxEnergy;

        halfEnergy = playerstats.MaxEnergy >> 1;    // Quick divide by 2
        quarterEnergy = playerstats.MaxEnergy >> 2; // Quick divide by 4

    }
	
	// Update is called once per frame
	void Update () {
        
        energySlider.size = playerstats.Energy/playerstats.MaxEnergy;


        if (playerstats.Energy < quarterEnergy)
        {
            Flash();
        }
        else //if (playerstats.Energy < halfEnergy)
        {
            ColorBlock cb = energySlider.colors;
            cb.normalColor = Color.Lerp(Color.red, Color.white, (playerstats.Energy - halfEnergy) / halfEnergy);

            energySlider.colors = cb;
        }
/*        else
        {
            ColorBlock cb = energySlider.colors;
            cb.normalColor = Color.white;

            energySlider.colors = cb;
        }
        */
        
    }

    void Flash()
    {

        if (flashDuration > FLASH_TIME)
        {
            flashDuration = 0;
            Color temp = flashStart;
            flashStart = flashEnd;
            flashEnd = temp;
        }
        else
        {
            flashDuration += Time.deltaTime;
            float percentage = flashDuration / FLASH_TIME;
            ColorBlock cb = energySlider.colors;

            cb.normalColor = Color.Lerp(flashStart, flashEnd, percentage);


            energySlider.colors = cb;
        }
    }

}
