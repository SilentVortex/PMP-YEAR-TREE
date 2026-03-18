using System.Security;
using UnityEngine;

public class DeleteOnWallHit : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isFiringLeft; // Determines the direction of the projectile
    [SerializeField] bool isFiringRight; // Determines the direction of the projectile

    void Start()
    {
        shootDirection();
    }
    void Update()
    {
        
    }
    // Called when this collider/rigidbody starts colliding with another collider/rigidbody
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the projectile if it hits a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // Destroy the projectile and damage the player if it hits the player
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            // Deal 1 damage to the player (if PlayerHealth component exists)
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }

    void shootDirection()
    {
        // Initialize the projectile's velocity for either left or right.
        if (isFiringLeft)
        {
            rb.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
        }
        else if (isFiringRight)
        {
            rb.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        }
        DestroyTimer();
    }
    void DestroyTimer()
    {
        // Destroy the projectile after a certain time to prevent it from existing indefinitely
        Destroy(gameObject, 5f); // Adjust the time as needed
    }    
}
