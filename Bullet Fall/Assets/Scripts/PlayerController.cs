using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 4.0f;
    [SerializeField] private float rotationSpeed;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;

    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();
        FireGun();
       
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0f,  verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    void FireGun()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
         if (Input.GetKey(KeyCode.Mouse0))
        {
           if (bullet != null) 
           {
           bullet.transform.position = gunMuzzle.transform.position;
           bullet.transform.rotation = gunMuzzle.transform.rotation;   
           
           bullet.SetActive(true);
           }
        }    
    }

    
}
