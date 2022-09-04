using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public int enemyCount;
    private float spawnTimer;
    private bool doTimer = true;
    public GameObject[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoints;
    public WaveData waveData;
    public  PickUpData pickUpData;
    public GameObject[] pickUps;
    public EnemyData enemyData;
    private int _roll;
     int pickUpsIndex;

     //Set local enemyNumber to dataFile enemyData
    void Awake()
    {
        waveData.enemyCount = 5;
        
        enemyCount = waveData.enemyCount;
        waveData.enemiesRemaining = 5;
        waveData.waveNumber = 1;
        pickUpData.spawn = false;
     
    }
 // Used for non time-crucial processing, i.e spawning offscreen
    void LateUpdate()
    {
        if(doTimer)
        {
          spawnTimer += Time.deltaTime;
        }

        Timer();
        CheckPickUp();
        
        

    }

    void Timer()
    {
      if(spawnTimer >= waveData.spawnTimerLimit)
        {
            RestSpawnTimer();
            if(enemyCount > 0)
            {
                int spawnIndex = Random.Range(0, 5);
                int enemyIndex = Random.Range(0,2);
                

                Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
                enemyCount--;
            }
           if(waveData.enemiesRemaining <= 0) 
            {
                IncrementEnemyCount();
                ResetEnemyCount();
                
            }
            
            
        }
    }


    void RestSpawnTimer()
    {
        spawnTimer = 0f;
    }

    void IncrementEnemyCount()
    {
        waveData.enemyCount++;
        waveData.waveNumber++;
    }

    void ResetEnemyCount()
    {
        enemyCount = waveData.enemyCount;
        waveData.enemiesRemaining = enemyCount;
    }

    void CheckPickUp()
    {
        if(pickUpData.spawn)
        {
            
            Roll(pickUpData.dropChance);
            SpawnPickUp();

        }

        
    }

    int Roll(int maxVal)
    {
        

        _roll = Random.Range(1, maxVal);
        Debug.Log("Roll: " + _roll);
        
            

        return _roll;
    }

    void SpawnPickUp()
    {
       pickUpsIndex = Random.Range(0,3);
        if(_roll == 1)
        {
            
           
        
       Instantiate(pickUps[pickUpsIndex], pickUpData.spawnLocation, Quaternion.identity);
      
       

        }
        pickUpData.spawn = false;
        Debug.Log("false");
    }

}
