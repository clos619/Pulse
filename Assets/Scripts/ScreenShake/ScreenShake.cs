using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public float linearIntensity = 0.25f;
    public float angularIntensity = 5f;
 

    float Intensity()
    {
        return linearIntensity * linearIntensity;
    }

    void Update () {
            LinearShaking ();
            //if (angularShaking)
                AngularShaking ();
        
    }
 
    private void LinearShaking () {
        Vector2 shake = UnityEngine.Random.insideUnitCircle * linearIntensity;
        Vector3 newPosition = transform.localPosition;
        newPosition.x = shake.x;
        newPosition.y = shake.y;
        transform.localPosition = newPosition;
    }
 
    private void AngularShaking () {
        float shake = UnityEngine.Random.Range (-Intensity() * angularIntensity, Intensity() * angularIntensity);
        transform.localRotation = Quaternion.Euler (0f, 0f, shake);
    }
 
 
    public void Enable () {
    }
 
    public void Disable () {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
