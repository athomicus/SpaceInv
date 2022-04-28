using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] public WaveConfigSO currentWaveSO;
    [SerializeField] List<WaveConfigSO> wavesList;
    [SerializeField] float timeBetweenWaves = 2f;
    private WaveConfigSO currentWave;
   
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

        void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
      foreach(WaveConfigSO wave in wavesList) 
      {
          currentWave = wave;

       for(int i = 0; i < wave.GetEnemyCount(); i++)
       {
        Instantiate(wave.GetEnemyPrefabToSpawn(i), wave.GetStartingWayPoint().position , Quaternion.identity, transform);
        yield return new WaitForSeconds(wave.GetTimeBetweenSpawn());
       }
       yield return new WaitForSeconds(timeBetweenWaves);

      }
    }

        public WaveConfigSO GetCurrentWave()
        {
            return currentWave;        
        } 
        
        public List<WaveConfigSO> GetWavesList()
        {
            return wavesList;
        }


}
