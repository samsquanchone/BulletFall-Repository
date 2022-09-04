using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration;
    private float lifeTimer;

    void Start()
    {
        lifeTimer = lifeDuration; //Setting local variable to accessable public variable value
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBullet(); 
        DestroyBullet();
    }

   protected virtual void MoveBullet()
    {
       //make bullet move

        transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    void DestroyBullet()
    {
        //Decrease life timer
        lifeTimer -= Time.deltaTime;

        //Destory if lifetimer reaches zero
       if(lifeTimer <= 0f)
        {
           this.gameObject.SetActive(false);
           ResetLifeTimer();

        }
    }

    //Reset bullet lifeTimer
    void ResetLifeTimer()
    {
       lifeTimer = lifeDuration;
    }

}
