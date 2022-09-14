using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollission : MonoBehaviour
{
    public PlayerData playerData;
    public PickUpData pickUpData;
    [SerializeField] private float timerDuration = 10f;

    

    protected  void Update()
    {
      timerDuration -= Time.deltaTime;
      if(timerDuration <= 0)
      {
          Destroy();
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
       ProcessCollision(collision.gameObject);
    }

    protected virtual void ProcessCollision(GameObject collider)
    {
        if(collider.gameObject.CompareTag("Player") && playerData.playerHealth < 100)
        {
            EventManager.TriggerEvent("PickUpHealth");
            HealPlayer();
            Destroy();
            
        }

    }

     protected void Destroy()
    {
        this.gameObject.SetActive(false);
    }


    private void HealPlayer()
    {
        Debug.Log("HealthObtained");

        
        
        playerData.playerHealth += pickUpData.amountToBuff;
        
        this.gameObject.SetActive(false);
     
    }
}
