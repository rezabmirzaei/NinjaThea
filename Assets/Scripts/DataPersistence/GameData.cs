using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    private HashSet<LevelData> LevelStatus { get; }

    public GameData()
    {
        LevelStatus = new HashSet<LevelData>();
    }

    public void UpdateLevelStatus(LevelData levelData)
    {
        LevelStatus.Add(levelData);
    }

    public override string ToString()
    {
        return LevelStatus.ToString();
    }

}
