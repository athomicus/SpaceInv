using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="WaveConfig",fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]  List<GameObject> enemyPrefabs;
    [SerializeField] float timeBetweenSpawnEnemy = 1f;
     [SerializeField]  Transform pathPrefab; //Prefab of Transforms path where enemy ship goes
     [SerializeField] float moveSpeed = 5f;
     public Transform GetStartingWayPoint()
     {
         return pathPrefab.GetChild(0);
     }

     public float GetTimeBetweenSpawn()
     {
         return timeBetweenSpawnEnemy;
     }
     
     


    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;        
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> PathEnemyList = new List<Transform>();
        
       
        foreach(Transform i in pathPrefab)  //for(int i = 0; i < pathPrefab.parent.childCount ; i++) {}
        {
          PathEnemyList.Add(i);  
        }
        return  PathEnemyList;
    }

    public GameObject GetEnemyPrefabToSpawn(int i)
    {
        return enemyPrefabs[i];
    }
}