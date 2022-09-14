using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationSpeed;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;
    public PlayerData playerData;
    private float shootCooldown;
    private bool canShoot;

    void Awake()
    {
        playerData.playerSpeed = movementSpeed;
        
        canShoot = true;
        shootCooldown = playerData.coolDown;
       // EventManager.TriggerEvent("StartGameMusic");
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();

        if (!canShoot)
        {
            shootCooldown -= Time.deltaTime;
          
            if (shootCooldown <= 0)
            {
                canShoot = true;
                ResetGunCooldown();

            }
        }
        FireGun();
       
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0f,  verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * playerData.playerSpeed * Time.deltaTime, Space.World);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    void FireGun()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
         if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            canShoot = false;

            EventManager.TriggerEvent("FireGunFmodEvent");
         
            if (bullet != null) 
           {
              bullet.transform.position = gunMuzzle.transform.position;
              bullet.transform.rotation = gunMuzzle.transform.rotation;   
           
              bullet.SetActive(true);
           }
        }    
    }

    void ResetGunCooldown()

    {
       
        shootCooldown = playerData.coolDown;
    }

    
}
