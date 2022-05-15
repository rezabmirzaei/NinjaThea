using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D coll;
    [SerializeField] private AudioSource deathSound;

    private bool isDead = false;

    public void Die()
    {
        deathSound.Play();
        GameController.Instance.EnemyKilled();
        isDead = true;
        animator.SetTrigger("Death");
        coll.enabled = false;
        this.enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
