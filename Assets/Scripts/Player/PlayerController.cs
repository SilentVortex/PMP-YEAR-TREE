//code is from https://github.com/LSBUGPG/movement-tutorial and https://qookie.games/2d-player-movement/, edited by me for this case.
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Movement speed in units per second
    public float moveSpeed = 7f;
	// Upward force applied when jumping
    public float jumpForce = 5f;
	// Tracks whether the player is currently on the ground
    bool isGrounded;
	// Cached Rigidbody2D component for physics interactions
    Rigidbody2D rb;
	// Reference to the player's Transform (could be this.transform)
    public Transform player;
	// Flag set when reaching a goal or instant-death object
    public bool goal = false;

	// Large damage value used for instant-death collisions
    private float kill = 1000.0f;

    void Start()
    {
		// Cache the Rigidbody2D component on start for better performance
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		// Read horizontal input (-1..1) and move the player accordingly
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(moveInput * moveSpeed * Time.deltaTime * Vector2.right);

		// If jump button pressed and player is grounded, apply vertical velocity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
			// NOTE: Rigidbody2D uses 'velocity' in Unity API (rb.velocity = ...).
			// This code sets linearVelocity; verify your API/version or change to rb.velocity if needed.
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		// When colliding with objects tagged "Ground", allow jumping again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
		// Instant death: mark goal and apply huge damage to player health
        if (collision.gameObject.CompareTag("InstantDeath"))
        {
            goal = true;
            player.GetComponent<PlayerHealth>().TakeDamage(kill);

        }

		// Goal reached: set goal flag and call Win on PlayerHealth
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal = true;
            player.GetComponent<PlayerHealth>().Win(goal);

        }

    }



    void OnCollisionExit2D(Collision2D collision)
    {
		// Leaving contact with ground disables grounded state
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}