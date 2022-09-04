using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyContoller : EnemyController
{
    public GameObject bulletPrefab;
    public Transform gunMuzzle;
    public float fireCooldown;
    private bool doTimer = false;

    void Start()
    {
        fireCooldown = enemyData.fireRate;
    }

    

    void Update()
    {
        if(doTimer)
        {
           fireCooldown -= Time.deltaTime;
           if(fireCooldown <= 0)
           {
               ResetCooldown();
           }
        }
        FireGun();
    }
    void FireGun()
    {      
           if(!doTimer)
           Instantiate(bulletPrefab, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
           doTimer = true;

          // bulletPrefab.transform.position = gunMuzzle.transform.position;
          // bulletPrefab.transform.rotation = gunMuzzle.transform.rotation;   
           

          // bulletPrefab.SetActive(true);
    }

    void ResetCooldown()
    {
        fireCooldown = enemyData.fireRate;
        doTimer = false;
    }
}
