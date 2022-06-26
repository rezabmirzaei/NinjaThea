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
        bool isEnemy = collision.gameObject.CompareTag("Enemy");
        if (isEnemy && collision.gameObject.GetComponent<Enemy>().IsDead()) return;

        if (isEnemy || collision.gameObject.CompareTag("Trap"))
        {
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
