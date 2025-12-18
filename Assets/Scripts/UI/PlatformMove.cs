using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // Distance the platform will move vertically when triggered
    [SerializeField] float moveDistance = 5.0f; 
    // Speed at which the platform moves
    [SerializeField] float moveSpeed = 2.0f;
    // Target position the platform will move to
    private Vector3 targetPosition;
    // Flag to indicate if the platform is currently moving
    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the target position to the platform's current position
        targetPosition = transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger, set the target position and enable movement
        if (other.CompareTag("Player"))
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y + moveDistance, transform.position.z);
            moving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the platform is moving, move it towards the target position
        if (moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            // Stop moving once the platform reaches the target position
            if (transform.position == targetPosition)
            {
                moving = false;
            }
        }
    }

    // The following methods are commented out but could be used to make the player a child of the platform while standing on it
    // This would allow the player to move with the platform

    //void OnCollisionEnter2D(Collision2D collision2D)
    //{
        //if (collision2D.gameObject.CompareTag("Player"))
        //{
            //collision2D.transform.SetParent(transform);
        //}
    //}

    //void OnCollisionExit2D(Collision2D collision2D)
    //{
        //if (collision2D.gameObject.CompareTag("Player"))
        //{
            //collision2D.transform.SetParent(null);
        //}
    //}
}
