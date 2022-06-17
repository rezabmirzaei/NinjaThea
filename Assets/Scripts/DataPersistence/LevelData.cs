using System;

public class LevelData
{
    public string LevelName { get; }
    public string CompletionTime { get; }

    public LevelData(string levelName, string completionTime)
    {
        LevelName = levelName;
        CompletionTime = completionTime;
    }

    public override int GetHashCode()
    {
        return (LevelName + CompletionTime).GetHashCode();
    }

    public override bool Equals(object obj)
    {
        LevelData levelData = obj as LevelData;
        return levelData != null
            && String.Equals(this.LevelName, levelData.LevelName)
            && String.Equals(this.CompletionTime, levelData.CompletionTime);
    }
}
