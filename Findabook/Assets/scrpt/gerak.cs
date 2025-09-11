using UnityEngine;
using UnityEngine.InputSystem;

public class gerak : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool Grounded;
    [SerializeField] private float jumpForce;
    private bool jumpPressedLastFrame = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        Grounded = IsGrounded();
        float jumpInput = Input.GetAxisRaw("Vertical");

        if (jumpInput > 0 && Grounded && !jumpPressedLastFrame)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpPressedLastFrame = true;
        }

        if (jumpInput == 0)
        {
            jumpPressedLastFrame = false;
        }

    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = movement;
    }
}