using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public int maxHealth = 3;
    private int currentHealth;
    public string deathSceneName = "GameOver";



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(deathSceneName);
    }

    public void Update()
    {
        Grounded = IsGrounded();
        float jumpInput = Input.GetAxisRaw("Vertical");

        if (jumpInput > 0 && Grounded && !jumpPressedLastFrame)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpPressedLastFrame = true;

            animator.SetBool("isJump", true);
        }

        if (jumpInput == 0)
        {
            jumpPressedLastFrame = false;

            animator.SetBool("isJump", false);
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

        float moveInput = Input.GetAxisRaw("Horizontal");
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