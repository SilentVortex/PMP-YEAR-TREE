
using UnityEngine;
using System;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float shootSpeed; // Shooting speed or rate
    [SerializeField] GameObject bulletLeft; // Bullet prefab to instantiate
    [SerializeField] GameObject bulletRight; // Bullet prefab to instantiate
    [SerializeField] Transform bulletSpawnPoint; // Spawn point for bullets
    // Reference to the player's Transform (could be this.transform)
    public Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        //StartCoroutine(Shoot());
        Shoot();
    }



    // Update is called once per frame

    //IEnumerator Shoot()
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
                if (player.GetComponent<PlayerController>().facingLeft == true)
                {
                    Instantiate(bulletLeft, bulletSpawnPoint.position, Quaternion.identity); // Instantiate the bullet at the spawn point
                }
                if (player.GetComponent<PlayerController>().facingRight == true)
                {
                    Instantiate(bulletRight, bulletSpawnPoint.position, Quaternion.identity); // Instantiate the bullet at the spawn point
                }   
            
        }
    }


}
