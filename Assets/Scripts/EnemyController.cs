using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public WaveData waveData;
    [SerializeField] Transform[] spawnPoints;
    public GameObject enemyPrefab;
    
    private float spawnTimer;
    private bool doTimer = true;


    // Update is called once per frame
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
            if(waveData.enemyCount > 0)
            {
                int spawnIndex = Random.Range(0, 5);

                Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                waveData.enemyCount--;
            }
           
            
            //ResetEnemyCount();
        }
    }


    void RestSpawnTimer()
    {
        spawnTimer = 0f;
    }

   /* void ResetEnemyCount()
    {
        enemyCount = 5;
    }
    */
}
