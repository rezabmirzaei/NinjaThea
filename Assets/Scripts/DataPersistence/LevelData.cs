using System;

[Serializable]
public class LevelData
{
    public string LevelName;
    public string CompletionTime;

    public LevelData(string levelName, string completionTime)
    {
        LevelName = levelName;
        CompletionTime = completionTime;
    }

    public override int GetHashCode()
    {
        return LevelName.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        LevelData levelData = obj as LevelData;
        return levelData != null
            && String.Equals(this.LevelName, levelData.LevelName);
    }

    public override string ToString()
    {
        return LevelName + ": " + CompletionTime;
    }
}
