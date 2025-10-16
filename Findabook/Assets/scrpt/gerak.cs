using UnityEngine;
using UnityEngine.InputSystem;


public class gerak : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool Grounded;
    [SerializeField] private float jumpForce;
    private bool jumpPressedLastFrame = false;
    public coinmanagement cm;
    [SerializeField] private Animator animator;
    private float xPostLastFrame;
    private float moveInput = 0f;
    private bool jumpRequest = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void MoveLeft()
    {
        moveInput = -1f;
    }

    public void MoveRight()
    {
        moveInput = 1f;
    }

    public void StopMoving()
    {
        moveInput = 0f;
    }

    public void JumpButton()
    {
        if (Grounded && !jumpPressedLastFrame)
        {
            jumpRequest = true;
        }
    }

    public void Update()
    {
        Grounded = IsGrounded();

        if (jumpRequest)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpRequest = false;
            jumpPressedLastFrame = true;

            animator.SetBool("isJump", true);
        }

        if (!jumpRequest)
        {
            jumpPressedLastFrame = false;

            animator.SetBool("isJump", false);
        }

        if (Grounded)
        {
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isJump", true);
        }

        FlipCharacterX();

       
    }

    public bool IsGrounded()
    {
       
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;

        
    }
        private void FlipCharacterX()
    {
        if (transform.position.x > xPostLastFrame)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < xPostLastFrame)
        {
            spriteRenderer.flipX = false;
        }

        xPostLastFrame = transform.position.x;
    }


    public void FixedUpdate()
    {

        Vector2 movement = new Vector2(moveInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = movement;

        if (moveInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            cm.coinCount++;
        }
    }
}