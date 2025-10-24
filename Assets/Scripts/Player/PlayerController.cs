//code is from https://github.com/LSBUGPG/movement-tutorial and https://qookie.games/2d-player-movement/, edited by me for this case.
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 5f;
    bool isGrounded;
    Rigidbody2D rb;
    public Transform player;
    public bool goal = false;

    private float kill = 1000.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(moveInput * moveSpeed * Time.deltaTime * Vector2.right);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("InstantDeath"))
        {
            goal = true;
            player.GetComponent<PlayerHealth>().TakeDamage(kill);

        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            goal = true;
            player.GetComponent<PlayerHealth>().Win(goal);

        }

    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}