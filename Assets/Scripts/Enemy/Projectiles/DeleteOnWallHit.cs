using System.Security;
using UnityEngine;

public class DeleteOnWallHit : MonoBehaviour
{
    public float bulletSpeed;
    void Update()
    {
        // Move the projectile forward based on its speed
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
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
}
