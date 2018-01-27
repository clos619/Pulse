using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public static ScreenShake Instance;
    public float linearIntensity = 0.25f;
    public float angularIntensity = 5f;

    [SerializeField]
    private bool angular = true;
    [SerializeField]
    private bool translation = true;
 
    [SerializeField]
    float magnitude = 2f;
    [SerializeField]
    float frequency = 10f;

    private float falloffSpeed = 1f;

    void Awake()
    {
        Instance = this;
    }

    public float Intensity()
    {
        return linearIntensity * linearIntensity;
    }

    void Update () {
            LinearShaking ();
            //if (angularShaking)
                AngularShaking ();

        if (linearIntensity > 0)
        {
            linearIntensity -= Time.deltaTime / falloffSpeed;
            linearIntensity = Mathf.Clamp01(linearIntensity);
        }
        
    }
 
    private void LinearShaking () {
        Vector2 shake = PerlinShake();
        Vector3 newPosition = transform.localPosition;
        newPosition.x = shake.x;
        newPosition.y = shake.y;
        transform.localPosition = newPosition;
    }
 
    private void AngularShaking () {
        float seed = Time.time * frequency;
        float shake = Mathf.Clamp01(Mathf.PerlinNoise (seed, 0f)) - 0.5f;
        shake = shake * angularIntensity * Intensity();
        transform.localRotation = Quaternion.Euler (0f, 0f, shake);
    }
 

    Vector2 PerlinShake ()
    {
        
        Vector2 result;
        float seed = Time.time * frequency;
        result.x = Mathf.Clamp01(Mathf.PerlinNoise (seed, 0f)) - 0.5f;
        result.y = Mathf.Clamp01(Mathf.PerlinNoise (0f, seed)) - 0.5f; 
        result = result * magnitude * Intensity();
        return result;
    }

    public void Shake(float amount, float falloff)
    {
        falloffSpeed = Mathf.Max(falloff, 0);
        amount = Mathf.Clamp01(amount);
        linearIntensity = amount;
    }

    public void Enable () {
    }
 
    public void Disable () {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
