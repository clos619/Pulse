using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

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

        //TODO: Abstract this if we need to load a different scene.
        AsyncOperation async = SceneManager.LoadSceneAsync("Movement");

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
