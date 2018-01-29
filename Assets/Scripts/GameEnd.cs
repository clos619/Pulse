using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {


	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(TimedGoodbye());
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
            Application.Quit();
	    }
	}

    IEnumerator TimedGoodbye()
    {
        yield return new WaitForSeconds(10f);

        TextBox.Instance.ShowText("[S1OWP0K3] Goodbye Captain", 3f);
    }
}
