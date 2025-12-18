using System.Runtime.Serialization;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public float speed; // Enemy movement speed
    public float shootSpeed; // Shooting speed or rate
    public GameObject bullet; // Bullet prefab to instantiate

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
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        shoot();
    }
    void shoot()
    {
        // Shooting logic here
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed; // Reverse direction upon hitting a wall
            //Vector3 scale = transform.localScale;
            //scale.x *= -1; // Flip the enemy sprite
            //transform.localScale = scale;
        }
    }
}
