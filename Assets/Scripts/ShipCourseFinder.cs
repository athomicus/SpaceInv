using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCourseFinder : MonoBehaviour
{

    EnemySpawner enemySpawner;
    List<Transform> wayPoints; 
   int wayPointsIndex = 0;
    
    private void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
       var a  = enemySpawner.GetCurrentWave(); 
       wayPoints = a.GetWayPoints();
       transform.position = wayPoints[wayPointsIndex].position; //setting start position

        
    }

    void Update()
    {
        Followpath();
    }

    void Followpath()
    {
        
        if(wayPointsIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointsIndex].position;
            float delta = enemySpawner.GetCurrentWave().GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,delta);
            if(transform.position == targetPosition) 
            {
                wayPointsIndex++;
            }
         }
         else
         {
            Destroy(gameObject);
         }
    }
}
