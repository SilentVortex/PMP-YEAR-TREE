using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Maximum health value for the enemy
    [SerializeField] float maxHealth = 100.0f;
    public float currentHealth;
    // Current health value, initialized to maxHealth at the start


    void Start()
    {
        // Initialize current health to maximum health
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce current health by the damage amount
        currentHealth -= damage;
        // If health drops to zero or below, trigger the death sequence
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Handle enemy death: destroy the enemy object
        Destroy(gameObject);
    }

}
