using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
   [SerializeField] int health = 60;
   [SerializeField] ParticleSystem hitExplosion;
   CameraShake cameraShake;
   [SerializeField] bool applyCamShake;
   AudioPlayer audioPlayer;
    Score score;
    [SerializeField] bool isPlayer;
    

 void Awake()
 {
    audioPlayer = FindObjectOfType<AudioPlayer>();
    cameraShake = Camera.main.GetComponent<CameraShake>();
    score = FindObjectOfType<Score>();
 }
void OnTriggerEnter2D(Collider2D other) {
    
    DamageGiver damageGiver = other.GetComponent<DamageGiver>();
    if(damageGiver!=null)
    {
        health -= damageGiver.GetDamage();
        if(isPlayer) 
         {
            score.SetSliderHealth(health);
         }

        ShakeCam();
        PlayHitPartileEffect();
        audioPlayer.PlayExplosionClip();
 
       
       if(health<=0)
        {
            score.SetScore(10); //+ 10 dla playera
            Destroy(gameObject);
        }
        
       
        damageGiver.Hit();
    }
   }

    private void ShakeCam()
    {
        if (cameraShake!=null && applyCamShake)
      {
         cameraShake.Play();
      };
    }

    void PlayHitPartileEffect()
   {
       if(hitExplosion!=null){
           ParticleSystem instance = Instantiate(hitExplosion,transform.position,Quaternion.identity);
           Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
   }

    
}
 