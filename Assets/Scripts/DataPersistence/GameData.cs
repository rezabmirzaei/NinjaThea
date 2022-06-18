using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public List<LevelData> LevelStatus;

    public GameData()
    {
        LevelStatus = new List<LevelData>();
    }

    public void UpdateLevelStatus(LevelData levelData)
    {
        // Avoid duplicates and only write over if better time
        int index = LevelStatus.FindIndex(ld => ld.Equals(levelData));
        if (index != -1)
        {
            LevelData allreadyPassedLevelData = LevelStatus[index];
            // TODO Check if allreadyPassedLevelData.CompletionTime is greater than levelData.CompletionTime
            // If so, replace ('cuz new one is better)
            LevelStatus[index] = levelData;
            return;
        }

        LevelStatus.Add(levelData);
    }

    public override string ToString()
    {
        return LevelStatus.ToString();
    }

}
