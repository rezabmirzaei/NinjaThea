using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.Instance.tasksCompleted)
        {
            finishLineCrossedSound.Play();
            GameController.Instance.LevelComplete();
        }
        else
        {
            GameController.Instance.DisplayTasksNotCompleteWarningText();
        }

    }

}
