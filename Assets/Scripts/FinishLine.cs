using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;

    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            if (GameController.Instance.TasksCompleted())
            {
                levelCompleted = true;
                finishLineCrossedSound.Play();
                Invoke("LoadNextScene", 2f);
            }
            else
            {
                Debug.Log("Complete all tasks first!");
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
