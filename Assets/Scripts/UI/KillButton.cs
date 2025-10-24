using UnityEngine;

public class KillButton : MonoBehaviour
{
    public Transform player;
    public float attackDamage = 10.0f;
    public void Damage()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
}
