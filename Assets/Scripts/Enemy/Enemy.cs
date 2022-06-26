using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D coll;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private LayerMask terrain;

    private bool isDead = false;

    private void FixedUpdate()
    {
        if (!isDead) return;
        // Enemy is dead. Disable once on the ground (falling down)
        if (isGrounded())
        {
            this.enabled = false;
        }
        transform.Translate(Vector2.down * 4.0f * Time.deltaTime, Space.World);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, terrain);
    }

    public void Die()
    {
        deathSound.Play();
        GameController.Instance.EnemyKilled();
        isDead = true;
        animator.SetTrigger("Death");
    }

    public bool IsDead()
    {
        return isDead;
    }
}
