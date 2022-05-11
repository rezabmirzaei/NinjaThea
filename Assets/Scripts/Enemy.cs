using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D coll;

    public void Die()
    {
        GameController.Instance.EnemyKilled();
        animator.SetTrigger("Death");
        coll.enabled = false;
        this.enabled = false;
    }
}
