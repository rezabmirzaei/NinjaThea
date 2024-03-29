using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;
    [SerializeField] private string levelCompleteAchievementID;
    [SerializeField] private bool isFinalStage;

    private bool isFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.tasksCompleted)
        {
            if (!isFinished)
            {
                isFinished = true;
                finishLineCrossedSound.Play();

                if (UserStatsHandler.Instance != null && levelCompleteAchievementID != null)
                    UserStatsHandler.Instance.PopAchievement(levelCompleteAchievementID);

                if (!isFinalStage) GameManager.Instance.StageComplete();
                else GameManager.Instance.GameComplete();

            }
        }
        else
        {
            GameManager.Instance.DisplayTasksNotCompleteWarningText();
        }

    }

    public bool IsFinalStage()
    {
        return isFinalStage;
    }

    public bool IsFinished() {
        return isFinished;
    }

}
