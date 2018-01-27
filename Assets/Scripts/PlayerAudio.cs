using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _clips = new List<AudioClip>();
    [SerializeField]
    private AudioSource _audio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnNoise(int soundId)
    {
        _audio.clip = _clips[Mathf.Min(soundId, _clips.Count)];
        _audio.Play();
    }

}
