using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tower : MonoBehaviour
{
    [SerializeField]
    private float _energy = 200;
    public float Energy {get {return _energy;}}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.tag == "Player")
        {
            Debug.Log("Player near tower!");
        }

        if (_energy > 0)
        {
            var player = other.GetComponent<PlayerStats>();
            player.Replenish(_energy);
            _energy = 0;
        }

    }
}
