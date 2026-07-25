
using UnityEngine;
using System;
using System.Collections;

public class EnemySoldier : MonoBehaviour
{
    [SerializeField] float speed; // Enemy movement speed
    [SerializeField] float shootSpeed; // Shooting speed or rate
    [SerializeField] GameObject bulletLeft; // Bullet prefab to instantiate
    [SerializeField] GameObject bulletRight; // Bullet prefab to instantiate
    [SerializeField] float Direction = 1; // Direction of movement (1 for right, -1 for left)
    [SerializeField] Transform bulletSpawnPoint; // Spawn point for bullets
    [SerializeField] private SpriteRenderer EnemySpriteRenderer; // Reference to the enemy's SpriteRenderer


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shoot()); // Start the shooting coroutines
    }

    void Update()
    {
        Move();
        FlipSprite();

    }

    // Update is called once per frame
    void Move()
    {   
        // Move the enemy horizontally
        transform.Translate(speed * Direction * Time.deltaTime,0,0);
        
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Direction *= -1; // Reverse direction upon hitting a wall
            FlipSprite();
        }
    }


    void FlipSprite()
    {
        if (EnemySpriteRenderer != null && Direction == -1)
        {
            EnemySpriteRenderer.flipX = true; // Flip the sprite horizontally when moving left
        }
        else if (EnemySpriteRenderer != null && Direction == 1)
        {
            EnemySpriteRenderer.flipX = false; // Reset the sprite flip when moving right
        }
    }
}
