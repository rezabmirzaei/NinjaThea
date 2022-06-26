using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = .8f;
    [SerializeField] private float attackRate = 4f;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private LayerMask enemyLayer;

    private float nextAttackTime = 0f;

    private void Update()
    {
        if (!gameObject.GetComponent<PlayerLife>().IsDead())
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    private void Attack()
    {
        attackSound.Play();
        if (rb.velocity.y > .1f || rb.velocity.y < -.1f)
        {
            animator.SetTrigger("Attack Jump");

        }
        else
        {
            animator.SetTrigger("Attack");

        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemyColl in hitEnemies)
        {
            Enemy enemy = enemyColl.GetComponent<Enemy>();
            if (!enemy.IsDead()) enemy.Die();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
