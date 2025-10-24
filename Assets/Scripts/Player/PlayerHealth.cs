
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100.0f;
    public float currentHealth = 0f;
    public GameObject deathScreen;
    public GameObject gameUI;
    public GameObject winScreen;


    void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1.0f;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    

    
    public void Win(bool goal)
    {
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
        gameObject.SetActive(false);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

}
