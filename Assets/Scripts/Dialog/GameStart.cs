using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public List<string> Lines = new List<string>();

    public int Index = 0;
	// Use this for initialization
	void Start ()
	{
	    Time.timeScale = 0;
        TextBox.Instance.OnDone.AddListener(OnDone);
        TextBox.Instance.ShowText(Lines[Index]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDone()
    {
        Index++;
        if (Index < Lines.Count)
        {
            TextBox.Instance.ShowText(Lines[Index]);
            return;
        }

        TextBox.Instance.OnDone.RemoveListener(OnDone);
        Time.timeScale = 1;
    }
}
