using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VissionCollision : MonoBehaviour {

    private GameOverManager gameOver;

	// Use this for initialization
	void Start () {
        gameOver = new global::GameOverManager();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Call death animation/game over stuff
        }
    }

}
