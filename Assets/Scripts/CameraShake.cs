
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShake : MonoBehaviour
{ 

    [SerializeField] float shakeDuration = 0.2f;
    [SerializeField] float shakeMagnitude = 0.5f;
    Vector3  initialPosition;
 
    
    void Start()
    {
     initialPosition = transform.position;
    
    }

     
     
     
 
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            elapsedTime+=Time.deltaTime;
            transform.position = initialPosition +(Vector3) Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
        
        
    }
}


