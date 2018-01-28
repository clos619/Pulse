using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject LoadingText;
    public GameObject Logo;
    public GameObject LoadingParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(string type)
    {
        StartCoroutine(LoadGameScene());
        
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(3);
        Logo.SetActive(false);
        Debug.Log("WTF", LoadingText);
        //LoadingText.SetActive(true);
        LoadingParticles.SetActive(true);

        //TODO: Abstract this if we need to load a different scene.
        AsyncOperation async = SceneManager.LoadSceneAsync("Game");

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
