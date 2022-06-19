using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpSound;

    private float horizontalMove = 0f;
    private bool jump = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask terrain;

    private enum MovementState { idle, running, jumping, falling }

    private void Update()
    {
        if (!gameObject.GetComponent<PlayerLife>().IsDead())
        {
            if (GameController.Instance.gamePlaying && !PauseMenu.isPaused)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal");

                if (Input.GetButtonDown("Jump") && isGrounded())
                {
                    jump = true;
                }
            }
            else
            {
                horizontalMove = 0;
                jump = false;
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