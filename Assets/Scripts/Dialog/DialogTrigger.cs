using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    [SerializeField] private string text;
    [SerializeField] private bool shown =false;

    [SerializeField] private float _showTime = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (shown == false)
        {
            return;
        }

        if (other.tag == "Player")
        {
            shown = true;
            TextBox.Instance.ShowText(text, _showTime);
        }
    }
}
