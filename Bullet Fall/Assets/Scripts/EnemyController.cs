using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public GameObject enemyPrefab;
    [SerializeField] int enemyCount = 5;
    [SerializeField] float spawnTimerLimit= 5f;
    private float spawnTimer;
    private bool doTimer = true;

    // Start is called before the first frame update
    void Start()
    {
       //RestSpawnTimer();
    }

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
      if(spawnTimer >= spawnTimerLimit)
        {
            RestSpawnTimer();
            if(enemyCount > 0)
            {
                int spawnIndex = Random.Range(0, 5);

                Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                enemyCount--;
            }
           
            
            //ResetEnemyCount();
        }
    }


    void RestSpawnTimer()
    {
        spawnTimer = 0f;
    }

    void ResetEnemyCount()
    {
        enemyCount = 5;
    }
}
