using System.Collections.Generic;

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
        // Avoid duplicates (handle replay og levels already completed)
        int index = LevelStatus.FindIndex(ld => ld == levelData);
        if (index != -1)
        {
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
