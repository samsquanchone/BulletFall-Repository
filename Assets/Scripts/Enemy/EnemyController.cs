using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public EnemyData enemyData;
    private GameObject playerObject;
    
  
    
   void Awake()
   {
       
       playerObject = GameObject.Find("Player");
       
       
   }

    // Used for time-crucial processing, i.e movement 
    void FixedUpdate()
    {
        if(playerObject != null)
       transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, enemyData.enemySpeed * Time.deltaTime);

    }

   
    
}
