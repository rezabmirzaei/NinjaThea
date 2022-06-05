using UnityEngine;

public class ResetSteamAchievements : MonoBehaviour
{

    [SerializeField] private bool resetAchievements;

    public void Start()
    {
        if (resetAchievements && SteamManager.Initialized)
        {
            Steamworks.SteamUserStats.ResetAllStats(true);
        }
    }
}
