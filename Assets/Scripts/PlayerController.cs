using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerLeft;
    [SerializeField] private Transform playerRight;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody2D rbLeft;
    private Rigidbody2D rbRight;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private int jumpCount = 2;

    void Start()
    {
        rbLeft = playerLeft.GetComponent<Rigidbody2D>();
        rbRight = playerRight.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");

        rbLeft.velocity = new Vector2(input * moveSpeed, rbLeft.velocity.y);
        rbRight.velocity = new Vector2(-input * moveSpeed, rbRight.velocity.y);

        bool isGrounded = IsGrounded();

        // Yere indiğimizde jumpCount sıfırlansın
        if (isGrounded)
        {
            jumpCount = 2;
        }

        // Zıplama kontrolü
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            // Zıplamayı düzgün hissettirmek için önce y hızını sıfırla
            rbLeft.velocity = new Vector2(rbLeft.velocity.x, 0f);
            rbRight.velocity = new Vector2(rbRight.velocity.x, 0f);

            // Sonra zıplama kuvveti ver
            rbLeft.velocity += new Vector2(0f, jumpForce);
            rbRight.velocity += new Vector2(0f, jumpForce);

            jumpCount--;
        }
    }

    bool IsGrounded()
    {
        bool leftGrounded = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, groundLayer);
        bool rightGrounded = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, groundLayer);
        return leftGrounded && rightGrounded;
    }
}