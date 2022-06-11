using UnityEngine;

public class ResetSteamAchievements : MonoBehaviour
{

    [SerializeField] private bool resetAchievements;

    public void Start()
    {
        if (resetAchievements && SteamManager.Initialized)
        {
            Debug.LogWarning("Resetting stats and achievements!");
            Steamworks.SteamUserStats.ResetAllStats(true);
        }
    }
}
