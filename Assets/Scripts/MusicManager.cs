using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<MusicManager>("MusicManager"));
                
            }

            return _instance;
        }
    }

    [SerializeField]
    private float defaultVolume = 0.5f;

    private float music2Time = -1;

    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private AudioSource _audio2;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);

	    _audio.volume = defaultVolume;
	    _audio2.volume = 0;
	}

    void Update()
    {
        music2Time -= Time.deltaTime;
        if (music2Time > 0)
        {
            _audio2.volume = Mathf.Clamp(_audio2.volume + Time.deltaTime, 0, defaultVolume);
            _audio.volume = Mathf.Clamp(_audio.volume - Time.deltaTime, .2f, defaultVolume);
        }
        else
        {
            _audio2.volume = Mathf.Clamp(_audio2.volume - Time.deltaTime, 0, defaultVolume);
            _audio.volume = Mathf.Clamp(_audio.volume + Time.deltaTime, .2f, defaultVolume);
        }
    }

    public void EnemyChase(float time = 2f)
    {
        music2Time = time;
    }

    /// <summary>
    /// Call to make sure it exists
    /// </summary>
    public void Exist()
    {

    }

}
