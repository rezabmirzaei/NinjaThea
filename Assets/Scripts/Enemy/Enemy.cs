using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D coll;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private LayerMask terrain;

    // Default behaviour is run - flip this in editor to change.
    [SerializeField] private bool idle;

    // Default behaviour is facing right - flip this in editor to face left.
    [SerializeField] private bool facingLeft;

    private bool dead = false;

    private void Start()
    {
        // Default behaviour is to start moving. Toggle idle in editor to keep anemy stationary.
        if (idle)
        {
            animator.SetTrigger("Idle");
        }
        if (facingLeft)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    // TODO not neccessary atm. Thea doesn't want flying enemies. To hard to kill for her...
    /* private void FixedUpdate()
    {
        if (!dead) return;
        // Enemy is dead. Disable once on the ground (falling down)
        while (!isGrounded()) transform.Translate(Vector2.down * 4.0f * Time.deltaTime, Space.World);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, terrain);
    } */

    public void Die()
    {
        deathSound.Play();
        GameManager.Instance.EnemyKilled();
        dead = true;
        coll.enabled = false;
        animator.SetTrigger("Death");
    }

    public bool IsDead()
    {
        return dead;
    }

    public bool IsIdle()
    {
        return idle;
    }

    public bool IsFacingLeft()
    {
        return facingLeft;
    }

}
