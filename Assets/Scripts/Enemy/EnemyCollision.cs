using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyData enemyData;
    public WaveData waveData;
    public PickUpData pickUpData;
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
         DeathLocation();
         this.gameObject.SetActive(false);
         waveData.enemiesRemaining--;
         waveData.score += enemyData.pointsValue;
         pickUpData.spawn = true;
         Debug.Log("true");
      }
    }

    public void DeathLocation()
    {
       Vector3 deathPosition = this.gameObject.transform.position;
       pickUpData.spawnLocation = deathPosition;
    }
}
