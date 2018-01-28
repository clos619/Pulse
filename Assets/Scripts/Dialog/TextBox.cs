using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public static TextBox Instance;

    [SerializeField]
    public Image _panel;
    [SerializeField]
    private TextMeshProUGUI _text;

    public UnityEvent OnDone;

	// Use this for initialization
	void Awake ()
	{
	    Instance = this;
        _panel.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
	    {
	        Progress();
	    }

	    if (Input.GetKeyDown(KeyCode.F))
	    {
            ShowText("Hello Pilot, this is the final message. Goodbye");
	    }
	}

    public void ShowText(string text)
    {
        _text.text = text;
        _text.maxVisibleCharacters = 0;
        _panel.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TextWrite());
    }

    IEnumerator TextWrite()
    {
        while (_text.maxVisibleCharacters < _text.text.Length)
        {
            _text.maxVisibleCharacters++;
            yield return new WaitForSecondsRealtime(0.050f);
        }
    }

    void Progress()
    {
        if (_text.maxVisibleCharacters < _text.text.Length)
        {
            _text.maxVisibleCharacters = _text.text.Length;
            return;
        }

        _panel.gameObject.SetActive(false);
        if (OnDone != null)
        {
            OnDone.Invoke();
        }
    }

    public void OnClick()
    {
        Progress();
        
    }

}
