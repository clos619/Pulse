using Assets.Scripts.Markers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMarkerhookup : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        MarkersUI.Instance.AddMarkerToTrack(GetComponent<Marker>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
