using UnityEngine;
using System;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float shootSpeed; // Shooting speed or rate
    [SerializeField] GameObject bulletLeft; // Bullet prefab to instantiate
    [SerializeField] GameObject bulletRight; // Bullet prefab to instantiate
    [SerializeField] float Direction = 1; // Direction of movement (1 for right, -1 for left)
    [SerializeField] Transform bulletSpawnPoint; // Spawn point for bullets


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        DirectionCheck();
        ShootCheck();
    }
    void ShootCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }

    void DirectionCheck()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Direction = -1; // Move left
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Direction = 1; // Move right
        }
    }

    IEnumerator Shoot()
    {
        for (;;)
        {
            if (Direction == -1)
            {
                Instantiate(bulletLeft, bulletSpawnPoint.position, Quaternion.identity); // Instantiate the bullet at the spawn point
            }
            else if (Direction == 1)
            {
                Instantiate(bulletRight, bulletSpawnPoint.position, Quaternion.identity); // Instantiate the bullet at the spawn point
            }
            // Instantiate the bullet at the spawn point
            yield return new WaitForSeconds(shootSpeed); // Wait for the specified shoot speed before shooting again
        }
    }
}
