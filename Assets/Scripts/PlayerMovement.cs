using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float horizontalMove = 0f;
    private bool jump = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask terrain;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump = true;
        }

        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horizontalMove > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
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