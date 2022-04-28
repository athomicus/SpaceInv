using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   [SerializeField] GameObject laserPrefab;
   [SerializeField] float shootSpeed = 10f;
   [SerializeField] float timeToNextShoot = 0.2f;
   [SerializeField] bool isEnemyAI;
   [HideInInspector] public bool isFiring;
   private float timePassed = 0;
   private bool shootingAllowed=true;
  
   AudioPlayer audioPlayer;
   void Awake()
   {
       audioPlayer = FindObjectOfType<AudioPlayer>();
      
   }

   

    void Start()
    {
        if(isEnemyAI) 
         {
             isFiring=true;
         }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed+=Time.deltaTime;
        if(timePassed > timeToNextShoot)
        {
            timePassed = 0;
            shootingAllowed=true;
        }

        if(isFiring&&shootingAllowed)  // Oddajemy strzał
        {
            
            GameObject instance = Instantiate(laserPrefab,transform.position,Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
          
             if(isEnemyAI) 
             {
                  audioPlayer.PlayShootingClip();
             }
             else
            {
                audioPlayer.PlayShootingPlayerClip();
            }

            if(rb!=null)
            {
                rb.velocity = transform.up * shootSpeed;
            }
        shootingAllowed=false;
        timePassed = 0;

        }
    }

    private  void FireAllowed()
    {
        

    }



}
