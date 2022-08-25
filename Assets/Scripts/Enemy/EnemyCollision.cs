using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyData enemyData;
    public WaveData waveData;
    public float enemyHealth;

     private void Start()
    {
        enemyHealth = enemyData.enemyHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
       ProcessCollision(collision.gameObject);
    }

    private void ProcessCollision(GameObject collider)
    {
        if(collider.gameObject.CompareTag("Bullet"))
        {
            DamageEnemy();
        }
    }

    private void DamageEnemy()
    {
      enemyHealth -= 10;
      Debug.Log("Health: " + enemyData.enemyHealth);

      if(enemyHealth <= 0)
      {
         this.gameObject.SetActive(false);
         waveData.enemiesRemaining--;
         waveData.score += enemyData.pointsValue;
      }
    }
}
