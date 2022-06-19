using System.Collections.Generic;
using System;

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
            // Check if levelData.CompletionTime is less than allreadyPassedLevelData.CompletionTime
            // If so, replace ('cuz new one is better)
            if (String.Compare(levelData.CompletionTime, allreadyPassedLevelData.CompletionTime) < 0)
            {
                LevelStatus[index] = levelData;
            }
            return;
        }

        LevelStatus.Add(levelData);
    }

    public override string ToString()
    {
        return LevelStatus.ToString();
    }

}
