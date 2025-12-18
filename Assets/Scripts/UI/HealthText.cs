using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    // Reference to the PlayerHealth script to access the player's current health
    public PlayerHealth playerHealth;
    // Reference to the TextMeshProUGUI component for displaying health
    private TextMeshProUGUI healthText;

    void Start()
    {
        // Cache the TextMeshProUGUI component attached to this GameObject
        healthText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update the health text to display the player's current health
        healthText.text = ":" + playerHealth.currentHealth.ToString();
    }
}
