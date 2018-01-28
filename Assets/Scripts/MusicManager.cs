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
    private AudioSource _audio;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

    /// <summary>
    /// Call to make sure it exists
    /// </summary>
    public void Exist()
    {

    }

}
