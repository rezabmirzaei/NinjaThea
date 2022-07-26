using Steamworks;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;
    [SerializeField] private string levelCompleteAchievementID;
    [SerializeField] private bool isFinalStage;


    private bool isFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.Instance.tasksCompleted)
        {
            if (!isFinished)
            {
                isFinished = true;
                finishLineCrossedSound.Play();

                if (UserStatsHandler.Instance != null && levelCompleteAchievementID != null)
                    UserStatsHandler.Instance.PopAchievement(levelCompleteAchievementID);

                if (!isFinalStage) GameController.Instance.StageComplete();
                else GameController.Instance.StageComplete();

            }
        }
        else
        {
            GameController.Instance.DisplayTasksNotCompleteWarningText();
        }

    }

}
