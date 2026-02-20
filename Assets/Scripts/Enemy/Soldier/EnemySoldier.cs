
using UnityEngine;
using System;

public class EnemySoldier : MonoBehaviour
{
    public float speed; // Enemy movement speed
    public float shootSpeed; // Shooting speed or rate
    public GameObject bullet; // Bullet prefab to instantiate
    private float Direction = 1; // Direction of movement (1 for right, -1 for left)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    // Update is called once per frame
    void Move()
    {   
        // Move the enemy horizontally
        transform.Translate(speed * Direction * Time.deltaTime,0,0);
        shoot();
    }
    void shoot()
    {
        // Shooting logic here
        //Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Direction *= -1; // Reverse direction upon hitting a wall
            // Reverse direction upon hitting a wall
            transform.localScale = new Vector3 (MathF.Abs(transform.localScale.x) * Direction,2,1); // Flip the enemy sprite
            //transform.localScale = scale;
        }
    }
}
