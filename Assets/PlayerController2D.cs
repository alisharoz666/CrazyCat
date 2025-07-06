using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpCount = 0;
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }

        // Jumping / Double Jumping
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    // Reset jump count when landing on ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we collided with a ground layer object
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            jumpCount = 0;
        }
    }
}
