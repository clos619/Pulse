using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public static GameOverManager Instance;

    [SerializeField] private Image _panel;

    [SerializeField] private Image _innerPanel;
    [SerializeField] private Image _innerOverPanel;

    private bool _gameover = false;

	// Use this for initialization
	void Awake ()
	{
	    Instance = this;
	}

    void Start()
    {
        _innerPanel.gameObject.SetActive(false);
        _panel.gameObject.SetActive(false);
        
        var color = _panel.color;
        color.a = 0;
        _panel.color = color;

        color.a = 1;
        _innerOverPanel.color = color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
    }

	// Update is called once per frame
	public void GameOver () {
        if(_gameover)
            return;

	    _gameover = true;

		//game over man, game over
	    Time.timeScale = 0;
        StopAllCoroutines();
	    StartCoroutine(FadeInPanel());
	}

    IEnumerator FadeInPanel()
    {
        _panel.gameObject.SetActive(true);
        _innerPanel.gameObject.SetActive(false);
        var fadeSpeed = 1.4f;
        var color = _panel.color;
        color.a = 0;
        _panel.color = color;
        var startTime = Time.realtimeSinceStartup;
        while (color.a < 1)
        {
            color.a += (Time.realtimeSinceStartup - startTime) / fadeSpeed;
            _panel.color = color;
            startTime = Time.realtimeSinceStartup;
            yield return 0;
        }

        _innerOverPanel.color = color;
        _innerPanel.gameObject.SetActive(true);

        fadeSpeed = 0.2f;
        startTime = Time.realtimeSinceStartup;
        while (color.a > 0)
        {
            color.a -= (Time.realtimeSinceStartup - startTime) / fadeSpeed;
            _innerOverPanel.color = color;
            startTime = Time.realtimeSinceStartup;
            yield return 0;
        }

        yield return 0;
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
