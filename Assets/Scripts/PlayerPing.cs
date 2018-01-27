using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPing : MonoBehaviour {

    [System.Serializable]
    public class PingEvent : UnityEvent<Transform>
    {
    }

    public PingEvent OnPing;

    private bool isPinging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Ping"))
        {
            Ping();
        }
	}

    private void Ping()
    {
        OnPing.Invoke(this.transform);
        //if (!isPinging)
        //{
            
        //}
    }
}
