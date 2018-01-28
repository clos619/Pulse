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
    private Image _panel;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Button _button;
    public UnityEvent OnDone;

    private float _time = -1;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private List<AudioClip> _voiceBlips = new List<AudioClip>();

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

	    //if (Input.GetKeyDown(KeyCode.F))
	    //{
     //       ShowText("Hello Pilot, this is the final message. Goodbye");
	    //}
	}

    public void ShowText(string text, float time = -1f)
    {
        _text.text = text;
        _text.maxVisibleCharacters = 0;
        _panel.gameObject.SetActive(true);
        StopAllCoroutines();
        _time = time;
        StartCoroutine(TextWrite());

        _button.gameObject.SetActive(_time < 0);
        

    }

    IEnumerator TextWrite()
    {
        bool other = true;
        bool blip = true;
        while (_text.maxVisibleCharacters < _text.text.Length)
        {
            _text.maxVisibleCharacters++;
            yield return new WaitForSecondsRealtime(0.050f);

            if (_text.maxVisibleCharacters-1 < _text.text.Length)
            {
                var curChar = _text.text[_text.maxVisibleCharacters-1];
                if (curChar == '[')
                {
                    blip = false;
                }
                else if (curChar == ']')
                {
                    blip = true;
                    other = false;
                }
            }

            if (other)
            {
                if (blip)
                {
                    _audio.clip = _voiceBlips[Random.Range(0, _voiceBlips.Count)];
                    _audio.Play();
                    other = false;
                }
            }
            else
            {
                other = true;
            }

        }

        if (_time > 0)
        {
            yield return new WaitForSecondsRealtime(_time);
            _time = -1;
            Progress();
        }

    }

    void Progress()
    {
        if (_text.maxVisibleCharacters < _text.text.Length)
        {
            _text.maxVisibleCharacters = _text.text.Length;
            return;
        }

        if(_time > 0)
            return;

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
