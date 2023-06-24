using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpSound;

    private float horizontalMove = 0f;
    private bool jump = false;
    private float coyoteTime = .1f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = .1f;
    private float jumpBufferCounter;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask terrain;

    private PlayerLife playerLife;
    private void Start()
    {
        playerLife = gameObject.GetComponent<PlayerLife>();
    }

    private void Update()
    {
        if (playerLife.IsDead())
        {
            horizontalMove = 0f;
            jump = false;
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
            animator.SetInteger("State", (int)MovementState.idle);
            return;
        }

        if (GameManager.Instance.gamePlaying && !PauseMenu.isPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            if (isGrounded())
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }
            if (Input.GetButtonDown("Jump"))
            {
                jumpBufferCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                jump = true;
            }
            UpdateAnimationState();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        if (jump)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horizontalMove != 0f)
        {
            state = MovementState.running;
            if ((horizontalMove < 0f && facingRight) || (horizontalMove > 0f && !facingRight))
            {
                facingRight = !facingRight;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("State", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, terrain);
    }

}