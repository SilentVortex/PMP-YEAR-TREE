using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Maximum health value for the player
    [SerializeField] float maxHealth = 100.0f;
    // Current health value, initialized to maxHealth at the start
    public float currentHealth = 0f;
    // Reference to the death screen UI object
    public GameObject deathScreen;
    // Reference to the in-game UI object
    public GameObject gameUI;
    // Reference to the win screen UI object
    public GameObject winScreen;


    void Start()
    {
        // Initialize current health to maximum health
        currentHealth = maxHealth;
        // Ensure the game runs at normal speed when starting
        Time.timeScale = 1.0f;
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
    

    
    public void Win(bool goal)
    {
        // If the player reaches the goal, disable the player and UI, pause the game, and show the win screen
        if (goal == true)
        {
            gameObject.SetActive(false);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
            winScreen.SetActive(true);
        }    
    }

    void Die()
    {
        // Handle player death: disable the player and UI, pause the game, and show the death screen
        gameObject.SetActive(false);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

}
