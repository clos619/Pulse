using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {
    public Text yourtime;
    public float startTime = 0;
    public float currentTime;
	// Use this for initialization
	void Start () {
        startTime = 0;
	}
	
	// Update is called once per frame
	void Update () {


        currentTime += Time.deltaTime;
        
        yourtime.text = "Current Time: " + currentTime;

    }
   
}
