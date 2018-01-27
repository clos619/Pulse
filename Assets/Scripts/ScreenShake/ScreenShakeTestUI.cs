using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShakeTestUI : MonoBehaviour
{
    public Slider Slider;
    public Scrollbar Bar;
    public Scrollbar Bar2;
    [SerializeField]
    private float testingFallOff = 3f;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Bar.size = ScreenShake.Instance.linearIntensity;
	    Bar2.size = ScreenShake.Instance.Intensity();
	}

    public void ShakeIt()
    {
        ScreenShake.Instance.Shake(Slider.value, testingFallOff);
    }

}
