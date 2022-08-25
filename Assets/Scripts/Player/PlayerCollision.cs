using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerData playerData;

    private void Start()
    {
        playerData.playerHealth = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
       ProcessCollision(collision.gameObject);
    }

    private void ProcessCollision(GameObject collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer();
        }
    }

    private void DamagePlayer()
    {
      playerData.playerHealth -= 10;
      Debug.Log("Health: " + playerData.playerHealth);

      if(playerData.playerHealth <= 0)
      {
        PlayerDead();
      }
    }

    public void PlayerDead()
    {
        gameObject.SetActive(false);
    }
}
