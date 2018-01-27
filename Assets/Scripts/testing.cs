using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {

    public float rotationSpeed = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(new Vector3(0f, Time.deltaTime * rotationSpeed, 0f));
	}
}
