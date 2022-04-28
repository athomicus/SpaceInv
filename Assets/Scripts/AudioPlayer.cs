using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("ShootingPlayer")]
    [SerializeField] AudioClip shootingPlayerClip;
    [SerializeField] [Range(0f,1f)] float shootingPlayerVolume = 1f;

   

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f,1f)] float explosionVolume = 1f;

   
    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, explosionVolume);
    }


    public void PlayShootingClip()
    {
        PlayClip(shootingClip,shootingVolume);
    }

     public void PlayShootingPlayerClip()
    {
        PlayClip(shootingPlayerClip,shootingPlayerVolume);
    }

   private void PlayClip(AudioClip clip, float volume)
    {
        var clipPosition = Camera.main.transform.position;
        if(clip!=null)
        {
            AudioSource.PlayClipAtPoint(clip,clipPosition, volume);
        }

    }
}
