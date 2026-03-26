using UnityEngine;
using System.Collections;

public class BossEnemy1 : MonoBehaviour
{
    [SerializeField] float shootSpeed; // Shooting speed or rate
    [SerializeField] GameObject bulletBoss1; // Bullet prefab to instantiate
    [SerializeField] GameObject player; // Reference to the player GameObject
    [SerializeField] float bulletSpeed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Boss1Shoot());
    }

    void Update()
    {
        FaceTowardsPlayer(); // Rotate the boss to face the player
    }

    // Update is called once per frame
 
    void ShootTowardsPlayer()
    {
        GameObject bullet = Instantiate(bulletBoss1, transform.position, transform.rotation); // Shoot in the direction the boss is facing
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply force in the direction the boss is facing
            rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse); // Adjust bulletSpeed to your desired force
        }
    }
     void FaceTowardsPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position; // Calculate the direction vector towards the player
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg; // Calculate the angle in degrees
        transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate the boss to face the player
    }

    IEnumerator Boss1Shoot()
    {
        for (;;)
        {
            ShootTowardsPlayer(); // Shoot in the direction the boss is facing
            yield return new WaitForSeconds(shootSpeed); // Wait for the specified shoot speed before shooting again
        }
    }
}
