using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthText.text = ":" + playerHealth.currentHealth.ToString();
    }
}
