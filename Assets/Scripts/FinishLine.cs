using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.instance.tasksCompleted)
        {
            finishLineCrossedSound.Play();
            GameController.instance.LevelComplete();
        }
        else
        {
            GameController.instance.DisplayTasksNotCompleteWarningText();
        }

    }

}
