using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (rb.velocity.y > .1f || rb.velocity.y < -.1f)
        {
            animator.SetTrigger("Attack Jump");

        }
        else
        {
            animator.SetTrigger("Attack");

        }
    }

}
