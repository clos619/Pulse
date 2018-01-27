using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPingReact : MonoBehaviour {

    public ParticleSystem thecoolpingableparticle;

	// Use this for initialization
	void Start () {
        thecoolpingableparticle = GetComponent<ParticleSystem>();
	}
	
	public void UsePing(Transform playerTransform)
    {
        if (thecoolpingableparticle.isPlaying)
            thecoolpingableparticle.Stop();
        thecoolpingableparticle.transform.position = playerTransform.position;
        thecoolpingableparticle.Play();
    }
}
