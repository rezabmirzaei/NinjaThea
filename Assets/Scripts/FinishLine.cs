using Steamworks;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;
    [SerializeField] private string levelCompleteAchievementID;

    private bool isFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.Instance.tasksCompleted)
        {
            if (!isFinished)
            {
                isFinished = true;
                finishLineCrossedSound.Play();

                // TODO handle this in separate class
                if (levelCompleteAchievementID != null && SteamManager.Initialized)
                {
                    Steamworks.SteamUserStats.GetAchievement(levelCompleteAchievementID, out bool achievementUnlocked);
                    if (!achievementUnlocked)
                    {
                        SteamUserStats.SetAchievement(levelCompleteAchievementID);
                        SteamUserStats.StoreStats();
                    }
                }

                GameController.Instance.LevelComplete();
            }
        }
        else
        {
            GameController.Instance.DisplayTasksNotCompleteWarningText();
        }

    }

}
