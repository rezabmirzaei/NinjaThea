using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;

    private bool isFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.Instance.tasksCompleted)
        {
            if (!isFinished)
            {
                isFinished = true;
                finishLineCrossedSound.Play();
                GameController.Instance.LevelComplete();
            }
        }
        else
        {
            GameController.Instance.DisplayTasksNotCompleteWarningText();
        }

    }

}
