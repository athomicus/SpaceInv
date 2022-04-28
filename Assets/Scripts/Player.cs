using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    ScreenBoundaries boundaries;
 
    private Vector2 rInput;
   
    [SerializeField]
    private float speed = 4.0f;
    CameraShake cameraShake;    
    Shooting shooting;
    void Awake()
    {
        shooting = GetComponent<Shooting>();
    }
       
    void Update()
    {
       Move();
    }
    void Start() 
    {
        boundaries = new ScreenBoundaries();
        cameraShake = FindObjectOfType<CameraShake>();

        
    }

    private void OnMove(InputValue value)
    {
        rInput = value.Get<Vector2>();
    }

    private void Move()  
    {
       Vector3 delta =  rInput * speed * Time.deltaTime;  
       transform.position = boundaries.SetLimitedPosition(transform.position + delta);
    }
 
 private void OnFire(InputValue value)
 {
     if(shooting!= null)
     {
         shooting.isFiring = value.isPressed;
     }
 } 

 private void OnTesting(InputValue value)
 {
       
       cameraShake.Play();
 }
    
}
