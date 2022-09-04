using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public EnemyData enemyData;
    private GameObject playerObject;
    public float speed = 1.0f;
    
  
    
   void Awake()
   {
       
       playerObject = GameObject.Find("Player");
       
       
   }

    // Used for time-crucial processing, i.e movement 
    void FixedUpdate()
    {
        if(playerObject != null)
       
         Move();
         Rotate();
    }

    void Move()
    {
       transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, enemyData.enemySpeed * Time.deltaTime);
    }

    void Rotate()
    {
        //Determining which direction to rotate towards
        Vector3 targetDirection = playerObject.transform.position - transform.position;
        //Step-speed for rotation
        float singleStep = speed * Time.deltaTime;
        //Rotate Vector towards the target
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        //Draw a ray pointing at our target
        Debug.DrawRay(transform.position, newDirection, Color.red);
         //Calculate a rotation a step closer to our target
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


   
    
}
