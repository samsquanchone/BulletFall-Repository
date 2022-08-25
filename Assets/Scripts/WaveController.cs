using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    private int enemyCount;
    private float spawnTimer;
    private bool doTimer = true;
    public GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    public WaveData waveData;

     //Set local enemyNumber to dataFile enemyData
    void Awake()
    {
        enemyCount = waveData.enemyCount;
        waveData.waveNumber = 1;
     
    }
 // Used for non time-crucial processing, i.e spawning offscreen
    void LateUpdate()
    {
        if(doTimer)
        {
          spawnTimer += Time.deltaTime;
        }

        Timer();
        

    }

    void Timer()
    {
      if(spawnTimer >= waveData.spawnTimerLimit)
        {
            RestSpawnTimer();
            if(enemyCount > 0)
            {
                int spawnIndex = Random.Range(0, 5);

                Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
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

}
