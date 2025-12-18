using UnityEngine;

public class KillButton : MonoBehaviour
{
    // Reference to the player's Transform to access their health
    public Transform player;
    // Amount of damage dealt when the button is pressed
    public float attackDamage = 10.0f;

    public void Damage()
    {
        // Apply damage to the player by calling the TakeDamage method in PlayerHealth
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
}
