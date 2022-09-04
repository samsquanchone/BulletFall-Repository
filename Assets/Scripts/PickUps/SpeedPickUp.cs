using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : PickUpCollission
{
    private bool toBuff = false;
    public float buffTimer;
    private float intialSpeed = 5f;

    void Awake()
    {
       
       buffTimer = pickUpData.buffDuration;
    }

    private void FixedUpdate()
    {
        if(toBuff)
        {
          Debug.Log("boom");
          buffTimer -= Time.deltaTime;


          if(buffTimer <= 0)
          {
              
            ResetPlayerSpeed();
            toBuff = false;
          }
        }
    }

    private void ResetPlayerSpeed()
    {
       playerData.playerSpeed = intialSpeed;
    }
    protected override void ProcessCollision(GameObject collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
          BuffPlayerSpeed();
          Destroy();

        }
    }

    private void BuffPlayerSpeed()
    {
        toBuff = true;
        playerData.playerSpeed += pickUpData.amountToBuff;
        
    }

   
}
