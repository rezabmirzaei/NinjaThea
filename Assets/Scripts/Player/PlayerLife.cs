using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isDead = true;
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // Enemies may fall from sky once dead, don't injure player if so
            if (collider.gameObject.GetComponent<Enemy>().IsDead()) return;
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        deathSound.Play();
        animator.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsDead()
    {
        return isDead;
    }

}
